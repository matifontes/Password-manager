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
            LoadCategories();
            CreateCreditCardPanel();
        }

        public CreateModifyCreditCard(CategoriesController categories, CreditCardsController creditCards, CreditCard creditCard)
        {
            InitializeComponent();
            this.categories = categories;
            this.creditCards = creditCards;
            this.creditCard = creditCard;
            LoadCategories();
            LoadCreditCardIntoFields();
            ModifyCreditCardPanel();
        }

        public void AddListener(HandlePostModification del) 
        {
            PostModification += del;
        }

        private void CreateCreditCardPanel() 
        {
            CreateCreditCard creditCardPanel = new CreateCreditCard();
            creditCardPanel.AddListener(CreateCreditCardEvent);
            operationPanel.Controls.Add(creditCardPanel);
        }

        private void ModifyCreditCardPanel() 
        {
            ModifyCreditCard creditCardPanel = new ModifyCreditCard();
            creditCardPanel.AddListener(ModifyCreditCardEvent);
            operationPanel.Controls.Add(creditCardPanel);
        }

        private void LoadCategories() 
        {
            foreach (Category category in this.categories.ListCategories()) 
            {
                cmbCategories.Items.Add(category);
            }
            cmbCategories.SelectedIndex = 0;
        }

        private void LoadCreditCardIntoFields() 
        {
            for (int i = 0; i < cmbCategories.Items.Count; i++)
            {
                if (cmbCategories.Items[i].ToString() == creditCard.Category.ToString())
                {
                    cmbCategories.SelectedItem = cmbCategories.Items[i];
                }
            }
            txtName.Text = creditCard.Name;
            txtType.Text = creditCard.Type;
            txtCCVCode.Text = creditCard.CCVCode.ToString();
            txtNumber.Text = creditCard.Number.ToString();
            txtNote.Text = creditCard.Note;
            dtpExpiryDate.Value = creditCard.ExpiryDate;
        }
        private void CreateCreditCardEvent() 
        {
            try
            {
                const string SUCCSESSFUL_CREATED = "Tarjeta de credito creada correctamente";
                CreditCard creditCard = new CreditCard((Category)cmbCategories.SelectedItem, txtName.Text, txtType.Text, long.Parse(txtNumber.Text), short.Parse(txtCCVCode.Text), dtpExpiryDate.Value, txtNote.Text);
                this.creditCards.AddCreditCard(creditCard);
                ShowMSG(System.Drawing.Color.Green, SUCCSESSFUL_CREATED);
                PostModification();
            }
            catch (Exception e) 
            {
                ShowMSG(System.Drawing.Color.Red,e.Message);
            }
        }

        private void ModifyCreditCardEvent() 
        {
            try
            {
                const string SUCCSESSFUL_MODIFY = "Tarjeta de credito modificada correctamente";
                creditCard.Category = (Category)cmbCategories.SelectedItem;
                creditCard.Name = txtName.Text;
                creditCard.Type = txtType.Text;
                creditCard.Number = long.Parse(txtNumber.Text);
                creditCard.CCVCode = short.Parse(txtCCVCode.Text);
                creditCard.ExpiryDate = dtpExpiryDate.Value;
                creditCard.Note = txtNote.Text;
                ShowMSG(System.Drawing.Color.Green, SUCCSESSFUL_MODIFY);
                PostModification();
            }
            catch (Exception e) 
            {
                ShowMSG(System.Drawing.Color.Red, e.Message);
            }
        }

        private void ShowMSG(System.Drawing.Color color, string message) 
        {
            lblMsg.ForeColor = color;
            lblMsg.Text = message;
        }
    }
}
