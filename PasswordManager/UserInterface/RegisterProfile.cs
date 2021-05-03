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
    public delegate void HandleRegister(SystemProfile profile);
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

        private void RegisterProfile_Load(object sender, EventArgs e)
        {

        }

        private void BtnCreateProfile_Click(object sender, EventArgs e)
        {
            if (VerifyNewPassword())
            {
                SystemProfile profile = new SystemProfile(txtPassword.Text);
                PostRegisterEvent(profile);
            }
            else {
                ShowErrorMSG();
            }         
        }

        private bool VerifyNewPassword() 
        {
            return txtPassword.Text.Equals(txtRepeatPassword.Text);
        }

        private void ShowErrorMSG() 
        {
            string ERROR_MSG_PASSWORDS_ARENT_EQUAL = "Las contraseñas no coinciden";
            lblErrorMsg.Text = ERROR_MSG_PASSWORDS_ARENT_EQUAL;
            lblErrorMsg.ForeColor = System.Drawing.Color.Red;
        }

    }
}
