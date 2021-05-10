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
using PasswordManager;

namespace UserInterface
{
    public partial class StrengthPassword : UserControl
    {
        private PasswordsController passwords;
        private event HandleBackToMenu ChangeToMenu;
        public StrengthPassword(PasswordsController passwords)
        {
            InitializeComponent();
            this.passwords = passwords;
            LoadPasswordCount();
            EnableOptions();
        }

        public void AddListener(HandleBackToMenu del)
        {
            ChangeToMenu += del;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            ChangeToMenu();
        }
        
        private void EnableOptions()
        {
           if (passwords.ListRedPasswords().Count == 0)
            {
                btnRedPassword.Enabled = false;
            }
            else
            {
                btnRedPassword.Enabled = true;
            }

            if (passwords.ListOrangePasswords().Count == 0)
            {
                btnOrangePassword.Enabled = false;
            }
            else
            {
                btnOrangePassword.Enabled = true;
            }

            if (passwords.ListYellowPasswords().Count == 0)
            {
                btnYellowPassword.Enabled = false;
            }
            else
            {
                btnYellowPassword.Enabled = true;
            }

            if (passwords.ListLightGreenPasswords().Count == 0)
            {
                btnLightGreenPassword.Enabled = false;
            }
            else
            {
                btnLightGreenPassword.Enabled = true;
            }

            if (passwords.ListDarkGreenPasswords().Count == 0)
            {
                btnDarkGreenPassword.Enabled = false;
            }
            else
            {
                btnDarkGreenPassword.Enabled = true;
            }
       
        }

        private void LoadPasswordCount()
        {
            lblCountRed.Text = passwords.ListRedPasswords().Count.ToString();
            lblCountOrange.Text = passwords.ListOrangePasswords().Count.ToString();
            lblCountYellow.Text = passwords.ListYellowPasswords().Count.ToString();
            lblCountLightGreen.Text = passwords.ListLightGreenPasswords().Count.ToString();
            lblCountDarkGreen.Text = passwords.ListDarkGreenPasswords().Count.ToString();
        }
    }
}
