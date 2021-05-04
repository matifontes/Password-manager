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
    public delegate void HandleWindowChange(UserControl panel);
    public delegate void HandleBackToMenu();
    public partial class MenuPanel : UserControl
    {
        private Profile profile;
        private event HandleWindowChange ChangeWindow;

        public MenuPanel(Profile profile)
        {
            InitializeComponent();
            this.profile = profile;
        }

        public void AddListener(HandleWindowChange del) 
        {
            ChangeWindow += del;
        }

        private void BtnCategories_Click(object sender, EventArgs e)
        {
            ListCategoriesPanel categories = new ListCategoriesPanel();
            categories.AddListener(ReturnToMenu);
            ChangeWindow(categories);
        }

        private void BtnPasswords_Click(object sender, EventArgs e)
        {
            ListPasswordsPanel passwords = new ListPasswordsPanel();
            passwords.AddListener(ReturnToMenu);
            ChangeWindow(passwords);
        }

        private void BtnCreditCards_Click(object sender, EventArgs e)
        {
            ListCreditCards creditCards = new ListCreditCards();
            creditCards.AddListener(ReturnToMenu);
            ChangeWindow(creditCards);
        }

        private void BtnBreaches_Click(object sender, EventArgs e)
        {

        }

        private void BtnPasswordStrangth_Click(object sender, EventArgs e)
        {

        }

        private void ReturnToMenu() 
        {
            ChangeWindow(this);
        }

    }
}
