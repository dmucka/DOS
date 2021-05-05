using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;
using System.Text.Json;

namespace DOS_PL.Auth
{
    public record AuthData
    {
        public AuthData(int userId, string roleName)
        {
            UserId = userId;
            RoleName = roleName;
        }

        public int UserId { get; set; }
        public string RoleName { get; set; }
    }

    // https://www.indie-dev.at/2020/04/06/custom-authentication-with-asp-net-core-3-1-blazor-server-side/
    public class DOSAuthStateProvider : AuthenticationStateProvider
    {
        private const string USER_SESSION_OBJECT_KEY = "user_session_obj";

        private readonly ProtectedSessionStorage _protectedSessionStore;
        private AuthData _cachedAuthData;

        public DOSAuthStateProvider(ProtectedSessionStorage protectedSessionStorage)
        {
            _protectedSessionStore = protectedSessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // read a possible user session object from the storage.
            var userSession = await GetUserSession();

            if (userSession != null)
                return await GenerateAuthenticationState(userSession);

            return await GenerateEmptyAuthenticationState();
      }

        public async Task LoginAsync(AuthData authData)
        {
            // store the session information in the client's storage.
            await SetUserSession(authData);

            // notify the authentication state provider.
            NotifyAuthenticationStateChanged(GenerateAuthenticationState(authData));
        }

        public async Task LogoutAsync()
        {
            // delete the user's session object.
            await SetUserSession(null);

            // notify the authentication state provider.
            NotifyAuthenticationStateChanged(GenerateEmptyAuthenticationState());
        }

        public async Task<int?> GetAuthorizedUser()
        {
            var session = await GetUserSession();

            if (session is null)
                return null;

            return session.UserId;
        }

        public async Task<AuthData> GetUserSession()
        {
            if (_cachedAuthData != null)
                return _cachedAuthData;

            var localUserJson = await _protectedSessionStore.GetAsync<string>(USER_SESSION_OBJECT_KEY);

            // no active user session found!
            if (!localUserJson.Success || string.IsNullOrEmpty(localUserJson.Value))
                return null;

            try
            {
                return RefreshUserSession(JsonSerializer.Deserialize<AuthData>(localUserJson.Value));
            }
            catch
            {
                // user could have modified to local value, leading to an
                // invalid decrypted object. Hence, the user just did destory
                // his own session object. We need to clear it up.
                await LogoutAsync();
                return null;
            }
        }

        private async Task SetUserSession(AuthData authData)
        {
            // buffer the current session into the user object,
            // in order to avoid fetching the user object from JS.
            RefreshUserSession(authData);

            await _protectedSessionStore.SetAsync(USER_SESSION_OBJECT_KEY, JsonSerializer.Serialize(authData));
        }

        private AuthData RefreshUserSession(AuthData authData) => _cachedAuthData = authData;

        private Task<AuthenticationState> GenerateAuthenticationState(AuthData authData)
        {
            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, authData.UserId.ToString()),
                new Claim(ClaimTypes.Role, authData.RoleName)
            }, "apiauth_type");

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            return Task.FromResult(new AuthenticationState(claimsPrincipal));
        }

        private Task<AuthenticationState> GenerateEmptyAuthenticationState() => Task.FromResult(new AuthenticationState(new ClaimsPrincipal()));
    }
}
