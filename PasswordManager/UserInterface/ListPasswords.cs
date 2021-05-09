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
    public partial class ListPasswordsPanel : UserControl
    {
        private PasswordsController passwords;
        private event HandleBackToMenu ChangeToMenu;
        public ListPasswordsPanel(PasswordsController passwords)
        {
            InitializeComponent();
            this.passwords = passwords;
        }

        public void AddListener(HandleBackToMenu del) 
        {
            ChangeToMenu += del;
        }

        private void BtnAddPassword_Click(object sender, EventArgs e)
        {

        }

        private void BtnModify_Click(object sender, EventArgs e)
        {

        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {

        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            ChangeToMenu();
        }
    }
}
