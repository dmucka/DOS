using Microsoft.AspNetCore.Components.Forms;
using System.Linq;

namespace DOS_PL.Validation
{
    /// <summary>
    /// EditForm validation css class provider that provides Bootstrap 4 style classes.
    /// </summary>
    public class BootstrapValidationCssClassProvider : FieldCssClassProvider
    {
        public override string GetFieldCssClass(EditContext editContext, in FieldIdentifier fieldIdentifier)
        {
            bool isValid = !editContext.GetValidationMessages(fieldIdentifier).Any();

            if (editContext.IsModified(fieldIdentifier) && isValid)
                return "is-valid e-success";

            return isValid ? "" : "is-invalid e-error";
        }
    }
}
