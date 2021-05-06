using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;

namespace DOS_PL.Validation
{
    // https://docs.microsoft.com/en-us/aspnet/core/blazor/forms-validation?view=aspnetcore-5.0#validator-components
    public class ServerSideValidator : ComponentBase
    {
        private ValidationMessageStore _messageStore;

        [CascadingParameter]
        EditContext CurrentEditContext { get; set; }

        /// <inheritdoc />
        protected override void OnInitialized()
        {
            if (CurrentEditContext == null)
            {
                throw new InvalidOperationException(
                    $"{nameof(ServerSideValidator)} requires a cascading " +
                    $"parameter of type {nameof(EditContext)}. " +
                    $"For example, you can use {nameof(ServerSideValidator)} " +
                    $"inside an {nameof(EditForm)}.");
            }

            _messageStore = new ValidationMessageStore(CurrentEditContext);
            CurrentEditContext.OnValidationRequested += (s, e) => _messageStore.Clear();
            CurrentEditContext.OnFieldChanged += (s, e) => _messageStore.Clear(e.FieldIdentifier);
        }

        public void DisplayError(string field, string message)
        {
            _messageStore.Add(CurrentEditContext.Field(field), message);
            CurrentEditContext.NotifyValidationStateChanged();
        }

        public void DisplayErrors(Dictionary<string, List<string>> errors)
        {
            foreach (var err in errors)
                _messageStore.Add(CurrentEditContext.Field(err.Key), err.Value);

            CurrentEditContext.NotifyValidationStateChanged();
        }

        public void ClearErrors()
        {
            _messageStore.Clear();
            CurrentEditContext.NotifyValidationStateChanged();
        }
    }
}
