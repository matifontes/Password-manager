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
        private Profile profile = null;

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
            registerPanel.AddListener(PostRegister);
            startPanel.Controls.Add(registerPanel);
            ReSizeForm(registerPanel.Width, registerPanel.Height);
        }

        private void CreateLoginPanel() {
            LoginPanel loginPanel = new LoginPanel(this.profile);
            loginPanel.AddListener(PostLogin);
            startPanel.Controls.Add(loginPanel);
            ReSizeForm(loginPanel.Width, loginPanel.Height);
        }

        private void CreateMenuPanel()
        {
            MenuPanel menuPanel = new MenuPanel(this.profile);
            menuPanel.AddListener(ChangeWindow);
            startPanel.Controls.Add(menuPanel);
            ReSizeForm(menuPanel.Width, menuPanel.Height);
        }

        private void ChangeWindow(UserControl panel) {
            ClearPanel();
            startPanel.Controls.Add(panel);
            ReSizeForm(panel.Width, panel.Height);
        }

        private void PostLogin() {
            ClearPanel();
            CreateMenuPanel();
        }

        private void PostRegister(Profile profile) {
            this.profile = profile;
            ClearPanel();
            CreateLoginPanel();
        }

        private void ReSizeForm(int width, int height) {
            int BORDER_MARGIN = 20;
            startPanel.Size = new Size(width, height);
            this.Size = new Size(width + BORDER_MARGIN, height + BORDER_MARGIN);
        }

        private void ClearPanel() {
            startPanel.Controls.Clear();
        }
    }
}
