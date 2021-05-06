using Microsoft.AspNetCore.Components.Forms;
using System.Linq;

namespace DOS_PL.Validation
{
    public class BootstrapValidationCssClassProvider : FieldCssClassProvider
    {
        public override string GetFieldCssClass(EditContext editContext, in FieldIdentifier fieldIdentifier)
        {
            var isValid = !editContext.GetValidationMessages(fieldIdentifier).Any();

            if (editContext.IsModified(fieldIdentifier) && isValid)
                return "is-valid e-success";

            return isValid ? "" : "is-invalid e-error";
        }
    }
}
