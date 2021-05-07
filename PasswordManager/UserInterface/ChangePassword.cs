using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PasswordManager;

namespace UserInterface
{
    public partial class ChangePassword : UserControl
    {
        private ProfileController profile;
        private event HandleBackToMenu ChangeToMenu;
        public ChangePassword(ProfileController profile)
        {
            InitializeComponent();
            this.profile = profile;
        }

        public void AddListener(HandleBackToMenu del) 
        {
            ChangeToMenu += del;
        }

        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            const string DIALOG_MSG = "Esta seguro de cambiar la contraseña?";
            const string DIALOG_ACTION = "Cambiar de contraseña";
            if (ConfirmDialog(DIALOG_MSG, DIALOG_ACTION))
            {
                if (txtNewPassword.Text.Equals(txtRepeatNewPassword.Text))
                {
                    try
                    {
                        profile.ChangePassword(txtActualPassword.Text, txtNewPassword.Text);
                        lblErrorMsg.Text = "Contraseña cambiada correctamente";
                        lblErrorMsg.ForeColor = System.Drawing.Color.Green;

                    }
                    catch (FailToValidatePasswordException exp) 
                    {
                        lblErrorMsg.ForeColor = System.Drawing.Color.Red;
                        lblErrorMsg.Text = exp.Message;
                    }
                }
                else 
                {
                    lblErrorMsg.ForeColor = System.Drawing.Color.Red;
                    lblErrorMsg.Text = "La contraseña nueva no coinciden";
                }

            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            ChangeToMenu();
        }

        private bool ConfirmDialog(string message, string action) 
        {
            DialogResult confirmDialog = MessageBox.Show(message, action, MessageBoxButtons.YesNo);
            return confirmDialog == DialogResult.Yes;
        }
    }
}
