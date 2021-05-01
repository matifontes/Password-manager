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
        private SystemProfile profile;

        public AppWindow()
        {
            InitializeComponent();
        }

        private void AppWindowLoader(object sender, EventArgs e)
        {
            CreateRegisterPanel();
        }

        private void CreateRegisterPanel() {
            RegisterProfile registerPanel = new RegisterProfile();
            startPanel.Controls.Add(registerPanel);
            ReSizeForm(registerPanel.Width, registerPanel.Height);
        }

        private void CreateLoginPanel() {
            LoginPanel loginPanel = new LoginPanel();
            startPanel.Controls.Add(loginPanel);
            ReSizeForm(loginPanel.Width, loginPanel.Height);
        }

        private void ReSizeForm(int width, int height) {
            startPanel.Size = new Size(width, height);
            this.Size = new Size(width, height + 20);
        }
    }
}
