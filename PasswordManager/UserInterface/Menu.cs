using System;
using System.Windows.Forms;
using PasswordManager.Controllers;

namespace UserInterface
{
    public delegate void HandleWindowChange(UserControl panel);
    public delegate void HandleBackToMenu();
    public delegate void HandlePostModification();
    public partial class MenuPanel : UserControl
    {
        private ProfileController profile;
        private CategoriesController categories;
        private PasswordsController passwords;
        private CreditCardsController creditCards;
        private event HandleWindowChange ChangeWindow;

        public MenuPanel(ProfileController profile,CategoriesController categories, PasswordsController passwords, CreditCardsController creditCards)
        {
            InitializeComponent();
            this.profile = profile;
            this.categories = categories;
            this.passwords = passwords;
            this.creditCards = creditCards;
        }

        public void AddListener(HandleWindowChange del) 
        {
            ChangeWindow += del;
        }

        private void BtnCategories_Click(object sender, EventArgs e)
        {
            ListCategoriesPanel categories = new ListCategoriesPanel(this.categories, this.profile);
            categories.AddListener(ReturnToMenu);
            ChangeWindow(categories);
        }

        private void BtnPasswords_Click(object sender, EventArgs e)
        {
            ListPasswordsPanel passwords = new ListPasswordsPanel(this.passwords,this.categories);
            passwords.AddListener(ReturnToMenu);
            ChangeWindow(passwords);
        }

        private void BtnCreditCards_Click(object sender, EventArgs e)
        {
            ListCreditCards creditCards = new ListCreditCards(this.creditCards,this.categories);
            creditCards.AddListener(ReturnToMenu);
            ChangeWindow(creditCards);
        }

        private void BtnBreaches_Click(object sender, EventArgs e)
        {
            DataBreach dataBreaches = new DataBreach(this.passwords, this.creditCards, this.categories);
            dataBreaches.AddListener(ReturnToMenu);
            dataBreaches.AddListener(ChangeWindow);
            ChangeWindow(dataBreaches);
        }

        private void BtnPasswordStrangth_Click(object sender, EventArgs e)
        {
            StrengthPassword strengthPassword = new StrengthPassword(passwords, categories);
            strengthPassword.AddListener(ReturnToMenu);
            strengthPassword.AddListener(ChangeWindow);
            ChangeWindow(strengthPassword);

        }
        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword(profile);
            changePassword.AddListener(ReturnToMenu);
            ChangeWindow(changePassword);
        }
        private void ReturnToMenu() 
        {
            ChangeWindow(this);
        }
    }
}
