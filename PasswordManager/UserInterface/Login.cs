using System;
using System.Windows.Forms;
using PasswordManager;

namespace UserInterface
{
    public delegate void HandleLogin();
    public partial class LoginPanel : UserControl
    {
        private Profile profile;
        private event HandleLogin PostLoginEvent;
        public LoginPanel(Profile profile)
        {
            InitializeComponent();
            this.profile = profile;
        }

        public void AddListener(HandleLogin del) {
            PostLoginEvent += del;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (profile.ValidateSystemPassword(txtPasswordInput.Text))
            {
                PostLoginEvent();
            }
            else {
                Console.WriteLine("No Valido");
            }
        }
    }
}
