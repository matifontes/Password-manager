using System;
using System.Windows.Forms;
using PasswordManager.Controllers;

namespace UserInterface
{
    public partial class StrengthPassword : UserControl
    {
        const string RED_STRENGTH = "Red";
        const string ORANGE_STRENGTH = "Orange";
        const string YELLOW_STRENGTH = "Yellow";
        const string LIGHTGREEN_STRENGTH = "LightGreen";
        const string DARKGREEN_STRENGTH = "DarkGreen";

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
            btnRedPassword.Enabled = passwords.ListPasswordsByStrength(RED_STRENGTH).Count != 0;
            btnOrangePassword.Enabled = passwords.ListPasswordsByStrength(ORANGE_STRENGTH).Count != 0;
            btnYellowPassword.Enabled = passwords.ListPasswordsByStrength(YELLOW_STRENGTH).Count != 0;
            btnLightGreenPassword.Enabled = passwords.ListPasswordsByStrength(LIGHTGREEN_STRENGTH).Count != 0;
            btnDarkGreenPassword.Enabled = passwords.ListPasswordsByStrength(DARKGREEN_STRENGTH).Count != 0;

        }

        private void LoadPasswordCount()
        {
            lblCountRed.Text = passwords.ListPasswordsByStrength(RED_STRENGTH).Count.ToString();
            lblCountOrange.Text = passwords.ListPasswordsByStrength(ORANGE_STRENGTH).Count.ToString();
            lblCountYellow.Text = passwords.ListPasswordsByStrength(YELLOW_STRENGTH).Count.ToString();
            lblCountLightGreen.Text = passwords.ListPasswordsByStrength(LIGHTGREEN_STRENGTH).Count.ToString();
            lblCountDarkGreen.Text = passwords.ListPasswordsByStrength(DARKGREEN_STRENGTH).Count.ToString();
        }

        private void BtnRedPassword_Click(object sender, EventArgs e)
        {
            ListStrengthPasswords redPasswords = new ListStrengthPasswords(this.passwords,categories, passwords.ListPasswordsByStrength(RED_STRENGTH));
            redPasswords.AddListener(ReturnToPasswordStrengh);
            ChangeWindow(redPasswords);
        }


        private void BtnOrangePassword_Click(object sender, EventArgs e)
        {
            ListStrengthPasswords orangePasswords = new ListStrengthPasswords(this.passwords, categories, passwords.ListPasswordsByStrength(ORANGE_STRENGTH));
            orangePasswords.AddListener(ReturnToPasswordStrengh);
            ChangeWindow(orangePasswords);
        }

        private void BtnYellowPassword_Click(object sender, EventArgs e)
        {
            ListStrengthPasswords yellowPasswords = new ListStrengthPasswords(this.passwords, categories, passwords.ListPasswordsByStrength(YELLOW_STRENGTH));
            yellowPasswords.AddListener(ReturnToPasswordStrengh);
            ChangeWindow(yellowPasswords);
        }

        private void BtnLightGreenPassword_Click(object sender, EventArgs e)
        {
            ListStrengthPasswords lightGreenPasswords = new ListStrengthPasswords(this.passwords, categories, passwords.ListPasswordsByStrength(LIGHTGREEN_STRENGTH));
            lightGreenPasswords.AddListener(ReturnToPasswordStrengh);
            ChangeWindow(lightGreenPasswords);
        }

        private void BtnDarkGreenPassword_Click(object sender, EventArgs e)
        {
            ListStrengthPasswords darkGreenPasswords = new ListStrengthPasswords(this.passwords, categories, passwords.ListPasswordsByStrength(DARKGREEN_STRENGTH));
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
