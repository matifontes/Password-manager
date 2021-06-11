using System;
using System.Windows.Forms;
using PasswordManager.Controllers;
using PasswordManager;
using PasswordManager.Exceptions;
using PasswordManagerDataLeyer.RepositoriesDB;

namespace UserInterface
{
    public partial class CreateModifyCreditCard : Form
    {
        const string INCORRECTFORMAT_EXPCEPTION_MSG = "Formato incorrecto de información";
        private CategoryRepository categories;
        private CreditCardRepository creditCards;
        private CreditCard creditCard;
        private ProfileController profile;
        private event HandlePostModification PostModification;
        public CreateModifyCreditCard(CategoryRepository categories, CreditCardRepository creditCards, ProfileController profile)
        {
            InitializeComponent();
            this.categories = categories;
            this.creditCards = creditCards;
            this.profile = profile;
            LoadCategories();
            CreateCreditCardPanel();
        }

        public CreateModifyCreditCard(CategoryRepository categories, CreditCardRepository creditCards, CreditCard creditCard, ProfileController profile)
        {
            InitializeComponent();
            this.categories = categories;
            this.creditCards = creditCards;
            this.creditCard = creditCard;
            this.profile = profile;
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
            foreach (Category category in this.categories.GetAll()) 
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
                string ccNumber = txtNumber.Text.Replace(" ", string.Empty);
                CreditCard creditCard = new CreditCard((Category)cmbCategories.SelectedItem, txtName.Text, txtType.Text, long.Parse(ccNumber), short.Parse(txtCCVCode.Text), dtpExpiryDate.Value, txtNote.Text);
                this.creditCards.Add(creditCard);
                ShowMSG(System.Drawing.Color.Green, SUCCSESSFUL_CREATED);
                PostModification();
            }catch (System.FormatException)
            {
                ShowMSG(System.Drawing.Color.Red, INCORRECTFORMAT_EXPCEPTION_MSG);
            }catch (Exception e)
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
                string ccNumber = txtNumber.Text.Replace(" ", string.Empty);
                creditCard.Number = long.Parse(ccNumber);
                creditCard.CCVCode = short.Parse(txtCCVCode.Text);
                creditCard.ExpiryDate = dtpExpiryDate.Value;
                creditCard.Note = txtNote.Text;
                this.creditCards.Update(creditCard);
                ShowMSG(System.Drawing.Color.Green, SUCCSESSFUL_MODIFY);
                PostModification();
            }catch(System.FormatException)
            {
                ShowMSG(System.Drawing.Color.Red, INCORRECTFORMAT_EXPCEPTION_MSG);
            }catch (Exception e) 
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
