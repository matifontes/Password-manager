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

        private void LoginPanelLoad(object sender, EventArgs e)
        {

        }

        public void AddListener(HandleLogin del) {
            PostLoginEvent += del;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (profile.ValidateSystemPassword(txtPasswordInput.Text))
            {
                Console.WriteLine("Valido");
            }
            else {
                Console.WriteLine("No Valido");
            }
        }
    }
}
