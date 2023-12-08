using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Infrastructure.Extension
{
    // http://www.asp.net/web-forms/tutorials/master-pages/control-id-naming-in-content-pages-cs
    public static class PageExtensionMethods
    {
        public static Control FindControlRecursive(this Control ctrl, string controlID)
        {
            if (String.Compare(ctrl.ID, controlID, true) == 0)
            {
                // We found the control!
                return ctrl;
            }

            // Recurse through ctrl's Controls collections
            foreach (Control child in ctrl.Controls)
            {
                Control lookFor = FindControlRecursive(child, controlID);

                if (lookFor != null)
                    return lookFor;  // We found the control
            }

            // If we reach here, control was not found
            return null;
        }

        public static void DisableControlRecursive(this Control ctrl, params string[] excludedControlNames)
        {
            if (!excludedControlNames.Contains(ctrl.ID) && ctrl is WebControl)
                (ctrl as WebControl).Enabled = false;

            foreach (Control child in ctrl.Controls)
            {
                DisableControlRecursive(child, excludedControlNames);
            }
        }

        public static void EnableValidationControlRecursive(this Control ctrl, string validationGroup, bool enabled)
        {
            foreach (Control control in ctrl.Controls)
            {
                if (control is BaseValidator && (control as BaseValidator).ValidationGroup == validationGroup)
                {
                    (control as WebControl).Enabled = enabled;
                }

                EnableValidationControlRecursive(control, validationGroup, enabled);
            }
        }

        public static void EnableValidationControlByName(this Control ctrl, string validationControlId, bool enabled)
        {
            foreach (Control control in ctrl.Controls)
            {
                if (control is BaseValidator && (control as BaseValidator).ID == validationControlId)
                {
                    (control as WebControl).Enabled = enabled;
                    return;
                }

                EnableValidationControlByName(control, validationControlId, enabled);
            }
        }
    }
}
