// // -------------------------------------------------------------------------
// // File: Datatables.cs
// // Author: Hughes, Donivan(hughes.dh.1)
// // Abstract: TODO: Add abstract
// //
// // Created: 07/12/2016 10:36 AM
// // Last Updated: 07/12/2016 10:36 AM
// // -------------------------------------------------------------------------
// 
// // -------------------------------------------------------------------------
// // Imports
// // -------------------------------------------------------------------------
using System.Windows.Forms;
using Control = System.Windows.Forms.Control;

namespace UExtensionLibrary.WinForms
{

    public static class WinForms
    {

        /// ------------------------------------------------------------------------------------------
        ///  Name: Clear
        ///  ------------------------------------------------------------------------------------------
        /// <summary> Clears all controls on the specified form</summary>
        /// <param name="frmToAffect">The FRM to affect.</param>
        ///  ------------------------------------------------------------------------------------------
        public static void Clear(this Form frmToAffect)
        {
            foreach (Control ctl in frmToAffect.Controls)
            {
                ctl.Clear();
            }
        }

        /// ------------------------------------------------------------------------------------------
        ///  Name: Clear
        ///  ------------------------------------------------------------------------------------------
        /// <summary> Clears the specified control. </summary>
        /// <param name="ctl">The control to clear</param>
        ///  ------------------------------------------------------------------------------------------
        public static void Clear(this Control ctl)
        {
           
                if (ctl is TextBox) ctl.Text = "";
                else if (ctl is CheckBox) ((CheckBox)ctl).Checked = false;
                else if (ctl is ComboBox) ((ComboBox)ctl).SelectedIndex = -1;
                else if (ctl is DataGridView) ((DataGridView)ctl).Rows.Clear();

                if (ctl.HasChildren)
                {
                    foreach (Control ctlChild in ctl.Controls)
                    {
                        ctlChild.Clear();
                    }
                }
        }
    }


 

    }
