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
            txtCCNumber.Text = this.creditCard.Number.ToString();
            txtCCV.Text = this.creditCard.CCVCode.ToString();
            txtExpiryDate.Text = this.creditCard.ExpiryDate.ToString();
            txtNote.Text = this.creditCard.Note;
        }

        private void CloseForm(object sender, EventArgs e) 
        {
            this.Dispose();
        }
    }
}
