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
    public delegate void HandleRegister(ProfileController profile);
    public partial class RegisterProfile : UserControl
    {
        private event HandleRegister PostRegisterEvent;

        public RegisterProfile()
        {
            InitializeComponent();
        }

        public void AddListener(HandleRegister del) {
            PostRegisterEvent += del;
        }

        private void BtnCreateProfile_Click(object sender, EventArgs e)
        {
            if (VerifyNewPassword())
            {
                ProfileController profile = new ProfileController(txtPassword.Text);
                PostRegisterEvent(profile);
            }
            else {
                ShowErrorMSGPasswordsArentEqual();
            }         
        }

        private bool VerifyNewPassword() 
        {
            return txtPassword.Text.Equals(txtRepeatPassword.Text);
        }

        private void ShowErrorMSGPasswordsArentEqual() 
        {
            string ERROR_MSG_PASSWORDS_ARENT_EQUAL = "Las contraseñas no coinciden";
            lblErrorMsg.Text = ERROR_MSG_PASSWORDS_ARENT_EQUAL;
            lblErrorMsg.ForeColor = System.Drawing.Color.Red;
        }

    }
}
