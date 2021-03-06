using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PasswordManager.Controllers;
using PasswordManager.Exceptions;
using PasswordManagerDataLeyer.RepositoriesDB;

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
            const string PASSWORD_CHANGED = "Contraseña Cambiada con exito";
            const string PASSWORD_DONT_MATCH = "La contraseña nueva no coinciden";
            if (ConfirmDialog(DIALOG_MSG, DIALOG_ACTION))
            {
                if (txtNewPassword.Text.Equals(txtRepeatNewPassword.Text))
                {
                    try
                    {
                        profile.ChangePassword(txtActualPassword.Text, txtNewPassword.Text);
                        ProfileRepository profileRepository = new ProfileRepository();
                        profileRepository.Update(profile.GetProfile());
                        ShowMSG(System.Drawing.Color.Green, PASSWORD_CHANGED);

                    }
                    catch (Exception exp) 
                    {
                        ShowMSG(System.Drawing.Color.Red, exp.Message);
                    }
                }
                else 
                {
                    ShowMSG(System.Drawing.Color.Red, PASSWORD_DONT_MATCH);
                }

            }
        }

        private void ShowMSG(System.Drawing.Color color, string message) 
        {
            lblErrorMsg.ForeColor = color;
            lblErrorMsg.Text = message;
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
