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
    public partial class AppWindow : Form
    {
        //harcoded profile
        private SystemProfile profile = new SystemProfile("1234");

        public AppWindow()
        {
            InitializeComponent();
        }

        private void AppWindowLoader(object sender, EventArgs e)
        {
            if (this.profile != null)
            {
                CreateLoginPanel();
            }
            else {
                CreateRegisterPanel();
            }
        }

        private void CreateRegisterPanel() {
            RegisterProfile registerPanel = new RegisterProfile();
            registerPanel.AddListener(PostLogin);
            startPanel.Controls.Add(registerPanel);
            ReSizeForm(registerPanel.Width, registerPanel.Height);
        }

        private void CreateLoginPanel() {
            LoginPanel loginPanel = new LoginPanel(this.profile);
            startPanel.Controls.Add(loginPanel);
            ReSizeForm(loginPanel.Width, loginPanel.Height);
        }

        private void PostLogin() { 
        
        }

        private void ReSizeForm(int width, int height) {
            int BORDER_MARGIN = 20;
            startPanel.Size = new Size(width, height);
            this.Size = new Size(width + BORDER_MARGIN, height + BORDER_MARGIN);
        }
    }
}
