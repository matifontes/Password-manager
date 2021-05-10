using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PasswordManager.Controllers;
using PasswordManager;

namespace UserInterface
{
    public partial class CreateModifyCreditCard : Form
    {
        private CategoriesController categories;
        private CreditCardsController creditCards;
        private CreditCard creditCard;
        private event HandlePostModification PostModification;
        public CreateModifyCreditCard(CategoriesController categories, CreditCardsController creditCards)
        {
            InitializeComponent();
            this.categories = categories;
            this.creditCards = creditCards;
        }

        public CreateModifyCreditCard(CategoriesController categories, CreditCardsController creditCards, CreditCard creditCard)
        {
            InitializeComponent();
            this.categories = categories;
            this.creditCards = creditCards;
            this.creditCard = creditCard;
        }

        public void AddListener(HandlePostModification del) 
        {
            PostModification += del;
        }
    }
}
