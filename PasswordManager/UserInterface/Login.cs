using System;
using System.Windows.Forms;
using PasswordManager;

namespace UserInterface
{
    public delegate void HandleLogin();
    public partial class LoginPanel : UserControl
    {
        private SystemProfile profile;
        private event HandleLogin PostLoginEvent;
        public LoginPanel(SystemProfile systemProfile)
        {
            InitializeComponent();
            this.profile = systemProfile;
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
