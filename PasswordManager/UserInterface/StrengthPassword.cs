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
        private CategoriesController categories;
        private event HandleBackToMenu ChangeToMenu;
        private event HandleWindowChange ChangeWindow;
        public StrengthPassword(PasswordsController passwords, CategoriesController categories)
        {
            InitializeComponent();
            this.passwords = passwords;
            this.categories = categories;
            LoadPasswordCount();
            EnableOptions();
        }

        public void AddListener(HandleBackToMenu del)
        {
            ChangeToMenu += del;
        }

        public void AddListener(HandleWindowChange del)
        {
            ChangeWindow += del;
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

        private void btnRedPassword_Click(object sender, EventArgs e)
        {
            ListStrengthPasswords redPasswords = new ListStrengthPasswords(passwords, categories, passwords.ListRedPasswords());
            redPasswords.AddListener(ReturnToMenu);
            ChangeWindow(redPasswords);
        }


        private void btnOrangePassword_Click(object sender, EventArgs e)
        {
            ListStrengthPasswords orangePasswords = new ListStrengthPasswords(passwords, categories, passwords.ListOrangePasswords());
            orangePasswords.AddListener(ReturnToMenu);
            ChangeWindow(orangePasswords);
        }

        private void btnYellowPassword_Click(object sender, EventArgs e)
        {
            ListStrengthPasswords yellowPasswords = new ListStrengthPasswords(passwords, categories, passwords.ListYellowPasswords());
            yellowPasswords.AddListener(ReturnToMenu);
            ChangeWindow(yellowPasswords);
        }

        private void btnLightGreenPassword_Click(object sender, EventArgs e)
        {
            ListStrengthPasswords lightGreenPasswords = new ListStrengthPasswords(passwords, categories, passwords.ListLightGreenPasswords());
            lightGreenPasswords.AddListener(ReturnToMenu);
            ChangeWindow(lightGreenPasswords);
        }

        private void btnDarkGreenPassword_Click(object sender, EventArgs e)
        {
            ListStrengthPasswords darkGreenPasswords = new ListStrengthPasswords(passwords, categories, passwords.ListDarkGreenPasswords());
            darkGreenPasswords.AddListener(ReturnToMenu);
            ChangeWindow(darkGreenPasswords);
        }
        
        private void ReturnToMenu()
        {
            ChangeWindow(this);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            ChangeToMenu();
        }
    }
}
