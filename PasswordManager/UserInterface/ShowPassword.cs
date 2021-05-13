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
    public partial class ShowPassword : Form
    {
        private Password password;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        public ShowPassword(Password password)
        {
            InitializeComponent();
            this.password = password;
            LoadPasswordIntoFields();
            timer.Interval = 30000;
            timer.Tick += new EventHandler(CloseForm);
            timer.Start();
        }

        private void LoadPasswordIntoFields() 
        {
            txtCategory.Text = this.password.Category.ToString();
            txtSite.Text = this.password.Site;
            txtUser.Text = this.password.User;
            txtPass.Text = this.password.Pass;
            txtDate.Text = this.password.LastModificationDate.ToString();
            txtNote.Text = this.password.Note;
        }

        private void CloseForm(object sender, EventArgs e) 
        {
            this.Dispose();
        }
    }
}
