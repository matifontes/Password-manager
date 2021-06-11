using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PasswordManager.Controllers;
using PasswordManagerDataLeyer.RepositoriesDB;
using PasswordManager;

namespace UserInterface
{
    public partial class StrengthPassword : UserControl
    {
        const string RED_STRENGTH = "Red";
        const string ORANGE_STRENGTH = "Orange";
        const string YELLOW_STRENGTH = "Yellow";
        const string LIGHTGREEN_STRENGTH = "LightGreen";
        const string DARKGREEN_STRENGTH = "DarkGreen";

        private PasswordRepository passwords;
        private ProfileController profile;
        private CategoryRepository categories;
        private DataBreachesController dBreachesController;
        private event HandleBackToMenu ChangeToMenu;
        private event HandleWindowChange ChangeWindow;
        public StrengthPassword(ProfileController profile, DataBreachesController dBreaches)
        {
            InitializeComponent();
            this.profile = profile;
            this.categories = new CategoryRepository(profile.GetProfile());
            this.passwords = new PasswordRepository(profile.GetProfile());
            this.dBreachesController = dBreaches;
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
            List<Password> redPasswords = (List<Password>)passwords.GetPasswordsByStrength(RED_STRENGTH);
            List<Password> orangePasswords = (List<Password>)passwords.GetPasswordsByStrength(ORANGE_STRENGTH);
            List<Password> yellowPasswords = (List<Password>)passwords.GetPasswordsByStrength(YELLOW_STRENGTH);
            List<Password> lightgreenPasswords = (List<Password>)passwords.GetPasswordsByStrength(LIGHTGREEN_STRENGTH);
            List<Password> darkgreenPasswords = (List<Password>)passwords.GetPasswordsByStrength(DARKGREEN_STRENGTH);
            btnRedPassword.Enabled = redPasswords.Count != 0;
            btnOrangePassword.Enabled = orangePasswords.Count != 0;
            btnYellowPassword.Enabled = yellowPasswords.Count != 0;
            btnLightGreenPassword.Enabled = lightgreenPasswords.Count != 0;
            btnDarkGreenPassword.Enabled = darkgreenPasswords.Count != 0;

        }

        private void LoadPasswordCount()
        {
            List<Password> redPasswords = (List<Password>)passwords.GetPasswordsByStrength(RED_STRENGTH);
            List<Password> orangePasswords = (List<Password>)passwords.GetPasswordsByStrength(ORANGE_STRENGTH);
            List<Password> yellowPasswords = (List<Password>)passwords.GetPasswordsByStrength(YELLOW_STRENGTH);
            List<Password> lightgreenPasswords = (List<Password>)passwords.GetPasswordsByStrength(LIGHTGREEN_STRENGTH);
            List<Password> darkgreenPasswords = (List<Password>)passwords.GetPasswordsByStrength(DARKGREEN_STRENGTH);
            lblCountRed.Text = redPasswords.Count.ToString();
            lblCountOrange.Text = orangePasswords.Count.ToString();
            lblCountYellow.Text = yellowPasswords.Count.ToString();
            lblCountLightGreen.Text = lightgreenPasswords.Count.ToString();
            lblCountDarkGreen.Text = darkgreenPasswords.Count.ToString();
        }

        private void BtnRedPassword_Click(object sender, EventArgs e)
        {
            ListStrengthPasswords redPasswords = new ListStrengthPasswords(this.passwords, categories, RED_STRENGTH, this.dBreachesController);
            redPasswords.AddListener(ReturnToPasswordStrengh);
            ChangeWindow(redPasswords);
        }


        private void BtnOrangePassword_Click(object sender, EventArgs e)
        {
            ListStrengthPasswords orangePasswords = new ListStrengthPasswords(this.passwords, categories, ORANGE_STRENGTH, this.dBreachesController);
            orangePasswords.AddListener(ReturnToPasswordStrengh);
            ChangeWindow(orangePasswords);
        }

        private void BtnYellowPassword_Click(object sender, EventArgs e)
        {
            ListStrengthPasswords yellowPasswords = new ListStrengthPasswords(this.passwords, categories, YELLOW_STRENGTH, this.dBreachesController);
            yellowPasswords.AddListener(ReturnToPasswordStrengh);
            ChangeWindow(yellowPasswords);
        }

        private void BtnLightGreenPassword_Click(object sender, EventArgs e)
        {
            ListStrengthPasswords lightGreenPasswords = new ListStrengthPasswords(this.passwords, categories, LIGHTGREEN_STRENGTH, this.dBreachesController);
            lightGreenPasswords.AddListener(ReturnToPasswordStrengh);
            ChangeWindow(lightGreenPasswords);
        }

        private void BtnDarkGreenPassword_Click(object sender, EventArgs e)
        {
            ListStrengthPasswords darkGreenPasswords = new ListStrengthPasswords(this.passwords, categories, DARKGREEN_STRENGTH, this.dBreachesController);
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
