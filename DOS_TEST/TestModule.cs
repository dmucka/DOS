using DOS_DAL;
using DOS_PL.Auth;
using LightInject;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS_TEST
{
    public class TestModule : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            // mock admin privileges
            serviceRegistry.RegisterScoped<DOSAuthStateProvider>(s =>
            {
                var provider = new DOSAuthStateProvider();
                provider.RefreshUserSession(new AuthData(1, "Admin"));
                return provider;
            });

            serviceRegistry.RegisterScoped<AuthenticationStateProvider>(s => s.GetInstance<DOSAuthStateProvider>());

            // mock db
            serviceRegistry.RegisterScoped<DOSContext>(s =>
            {
                var authProvider = s.GetInstance<DOSAuthStateProvider>();
                var dbcontext = new TestDbContext(authProvider.GetAuthorizedUser);
                dbcontext.Database.EnsureCreated();
                return dbcontext;
            });

            // register normal services
            serviceRegistry.RegisterFrom<DOS_BL.BusinessLayerModule>();
        }
    }
}
