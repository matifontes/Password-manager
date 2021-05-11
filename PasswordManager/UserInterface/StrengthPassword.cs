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
            btnRedPassword.Enabled = passwords.ListRedPasswords().Count != 0;
            btnOrangePassword.Enabled = passwords.ListOrangePasswords().Count != 0;
            btnYellowPassword.Enabled = passwords.ListYellowPasswords().Count != 0;
            btnLightGreenPassword.Enabled = passwords.ListLightGreenPasswords().Count != 0;
            btnDarkGreenPassword.Enabled = passwords.ListDarkGreenPasswords().Count != 0;

        }

        private void LoadPasswordCount()
        {
            lblCountRed.Text = passwords.ListRedPasswords().Count.ToString();
            lblCountOrange.Text = passwords.ListOrangePasswords().Count.ToString();
            lblCountYellow.Text = passwords.ListYellowPasswords().Count.ToString();
            lblCountLightGreen.Text = passwords.ListLightGreenPasswords().Count.ToString();
            lblCountDarkGreen.Text = passwords.ListDarkGreenPasswords().Count.ToString();
        }

        private void BtnRedPassword_Click(object sender, EventArgs e)
        {
            const string STRENGTH_RED = "Red";
            ListStrengthPasswords redPasswords = new ListStrengthPasswords(categories, passwords.ListRedPasswords(), STRENGTH_RED);
            redPasswords.AddListener(ReturnToPasswordStrengh);
            ChangeWindow(redPasswords);
        }


        private void BtnOrangePassword_Click(object sender, EventArgs e)
        {
            const string STRENGTH_ORANGE = "Orange";
            ListStrengthPasswords orangePasswords = new ListStrengthPasswords(categories, passwords.ListOrangePasswords(), STRENGTH_ORANGE);
            orangePasswords.AddListener(ReturnToPasswordStrengh);
            ChangeWindow(orangePasswords);
        }

        private void BtnYellowPassword_Click(object sender, EventArgs e)
        {
            const string STRENGTH_YELLOW = "Yellow";
            ListStrengthPasswords yellowPasswords = new ListStrengthPasswords(categories, passwords.ListYellowPasswords(), STRENGTH_YELLOW);
            yellowPasswords.AddListener(ReturnToPasswordStrengh);
            ChangeWindow(yellowPasswords);
        }

        private void BtnLightGreenPassword_Click(object sender, EventArgs e)
        {
            const string STRENGTH_LGREEN = "LightGreen";
            ListStrengthPasswords lightGreenPasswords = new ListStrengthPasswords(categories, passwords.ListLightGreenPasswords(), STRENGTH_LGREEN);
            lightGreenPasswords.AddListener(ReturnToPasswordStrengh);
            ChangeWindow(lightGreenPasswords);
        }

        private void BtnDarkGreenPassword_Click(object sender, EventArgs e)
        {
            const string STRENGTH_DGREEN = "DarkGreen";
            ListStrengthPasswords darkGreenPasswords = new ListStrengthPasswords(categories, passwords.ListDarkGreenPasswords(), STRENGTH_DGREEN);
            darkGreenPasswords.AddListener(ReturnToPasswordStrengh);
            ChangeWindow(darkGreenPasswords);
        }
        
        private void ReturnToPasswordStrengh()
        {
            EnableOptions();
            LoadPasswordCount();
            ChangeWindow(this);
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            ChangeToMenu();
        }
    }
}
