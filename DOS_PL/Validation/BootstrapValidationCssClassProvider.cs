using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;

namespace DOS_PL.Validation
{
    public class BootstrapValidationCssClassProvider : FieldCssClassProvider
    {
        public override string GetFieldCssClass(EditContext editContext, in FieldIdentifier fieldIdentifier)
        {
            var isValid = !editContext.GetValidationMessages(fieldIdentifier).Any();

            if (editContext.IsModified(fieldIdentifier) && isValid)
                return "is-valid";

            return isValid ? "" : "is-invalid";
        }
    }
}
