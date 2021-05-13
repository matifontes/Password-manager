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
                try
                {
                    ProfileController profile = new ProfileController(txtPassword.Text);
                    PostRegisterEvent(profile);
                } 
                catch(Exception exp)
                {
                    ShowMSG(System.Drawing.Color.Red, exp.Message);
                }
            }
            else {
                string ERROR_MSG_PASSWORDS_ARENT_EQUAL = "Las contraseñas no coinciden";
                ShowMSG(System.Drawing.Color.Red, ERROR_MSG_PASSWORDS_ARENT_EQUAL);
            }         
        }

        private bool VerifyNewPassword() 
        {
            return txtPassword.Text.Equals(txtRepeatPassword.Text);
        }

        private void ShowMSG(System.Drawing.Color color, string message) 
        {
            lblErrorMsg.Text = message;
            lblErrorMsg.ForeColor = color;
        }
    }
}
