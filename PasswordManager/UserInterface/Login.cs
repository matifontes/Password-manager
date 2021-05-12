using System;
using System.Windows.Forms;
using PasswordManager.Controllers;

namespace UserInterface
{
    public delegate void HandleLogin();
    public partial class LoginPanel : UserControl
    {
        private ProfileController profile;
        private event HandleLogin PostLoginEvent;
        public LoginPanel(ProfileController profile)
        {
            InitializeComponent();
            this.profile = profile;
        }

        public void AddListener(HandleLogin del) {
            PostLoginEvent += del;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (profile.ValidatePassword(txtPasswordInput.Text))
            {
                PostLoginEvent();
            }
            else {
                const string FAIL_LOGIN = "Contraseña incorrecta";
                ShowMSG(System.Drawing.Color.Red, FAIL_LOGIN);
            }
        }

        private void ShowMSG(System.Drawing.Color color,string message) 
        {
            lblErrorMsg.ForeColor = color;
            lblErrorMsg.Text = message;
        }
    }
}
