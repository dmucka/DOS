using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.ComponentModel.DataAnnotations;

namespace DOS_PL.Validation
{
    public class OptionalFieldValidator : ComponentBase
    {
        [CascadingParameter]
        EditContext CurrentEditContext { get; set; }

        /// <inheritdoc />
        protected override void OnInitialized()
        {
            if (CurrentEditContext == null)
            {
                throw new InvalidOperationException(
                    $"{nameof(OptionalFieldValidator)} requires a cascading " +
                    $"parameter of type {nameof(EditContext)}. " +
                    $"For example, you can use {nameof(OptionalFieldValidator)} " +
                    $"inside an {nameof(EditForm)}.");
            }

            CurrentEditContext.OnFieldChanged += (s, e) =>
            {
                var prop = e.FieldIdentifier.Model.GetType().GetProperty(e.FieldIdentifier.FieldName);
                if (prop == null || prop.PropertyType != typeof(string))
                    return;

                // continue only if the property does not have the Required attribute
                if (prop.GetCustomAttributes(typeof(RequiredAttribute), false).Length != 0)
                    return;

                // check if the string is empty
                if (prop.GetValue(e.FieldIdentifier.Model) as string == "")
                {
                    prop.SetValue(e.FieldIdentifier.Model, null);
                    CurrentEditContext.NotifyFieldChanged(e.FieldIdentifier);
                    CurrentEditContext.MarkAsUnmodified(e.FieldIdentifier);
                    CurrentEditContext.Validate();
                    StateHasChanged();
                }
            };
        }
    }
}
