using System;
using System.Windows.Forms;
using PasswordManager;

namespace UserInterface
{
    public partial class ShowCreditCard : Form
    {
        private CreditCard creditCard;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        public ShowCreditCard(CreditCard creditCard)
        {
            InitializeComponent();
            this.creditCard = creditCard;
            LoadCreditCardIntoFields();
            timer.Interval = 30000;
            timer.Tick += new EventHandler(CloseForm);
            timer.Start();
        }

        private void LoadCreditCardIntoFields() 
        {
            txtCategory.Text = this.creditCard.Category.ToString();
            txtName.Text = this.creditCard.Name;
            txtType.Text = this.creditCard.Type;
            string creditCardNumber = this.creditCard.Number.ToString().Substring(0,4);
            creditCardNumber += " " + this.creditCard.Number.ToString().Substring(4, 4);
            creditCardNumber += " " + this.creditCard.Number.ToString().Substring(8, 4);
            creditCardNumber += " " + this.creditCard.Number.ToString().Substring(12, 4);
            txtCCNumber.Text = creditCardNumber;
            txtCCV.Text = this.creditCard.CCVCode.ToString();
            txtExpiryDate.Text = this.creditCard.ExpiryDate.ToString("MM/yy");
            txtNote.Text = this.creditCard.Note;
        }

        private void CloseForm(object sender, EventArgs e) 
        {
            this.Dispose();
        }
    }
}
