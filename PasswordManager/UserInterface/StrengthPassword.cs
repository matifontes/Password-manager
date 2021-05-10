using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PasswordManager.Controllers;

namespace UserInterface
{
    public partial class StrengthPassword : UserControl
    {
        private PasswordsController passwords;
        private event HandleBackToMenu ChangeToMenu;
        public StrengthPassword()
        {
            InitializeComponent();
            this.passwords = passwords;
            LoadPasswordCount();
  
        }

        public void AddListener(HandleBackToMenu del)
        {
            ChangeToMenu += del;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            ChangeToMenu();
        }


        private void LoadPasswordCount()
        {
        }
    }
}
