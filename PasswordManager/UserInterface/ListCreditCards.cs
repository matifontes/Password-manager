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
using PasswordManager.Controllers;

namespace UserInterface
{
    public partial class ListCreditCards : UserControl
    {
        private CreditCardsController creditCards;
        private CategoriesController categories;
        private CreateModifyCreditCard creditCardForm;
        private event HandleBackToMenu ChangeToMenu;
        public ListCreditCards(CreditCardsController creditCards, CategoriesController categories)
        {
            InitializeComponent();
            this.creditCards = creditCards;
            this.categories = categories;
            //harcoded creaditCards
            if (this.creditCards.Count() == 0) 
            {
                this.creditCards.AddCreditCard(new CreditCard(new Category("Personal"),"Visa Gold", "Visa",3212314543432456,090,DateTime.Today,"nota"));
                this.creditCards.AddCreditCard(new CreditCard(new Category("Trabajo"), "Visa Gold", "Visa", 3212314543432456, 090, DateTime.Today, "nota"));
                this.creditCards.AddCreditCard(new CreditCard(new Category("Gaming"), "Visa Gold", "Visa", 3212314543432456, 090, DateTime.Today, "nota"));
            }
            LoadCategoriesList();
        }

        public void AddListener(HandleBackToMenu del) 
        {
            ChangeToMenu += del;
        }

        private void LoadCategoriesList() 
        {
            List<CreditCard> orderedCreditCard = this.creditCards.ListCreditCards();
            DataTable dataTable = InitializeDataTable();

            foreach (CreditCard creditCard in orderedCreditCard)
            {
                DataRow row = dataTable.NewRow();
                row["Categoría"] = creditCard.Category;
                row["Nombre"] = creditCard;
                row["Tipo"] = creditCard.Type;
                string XXNo = "XXXX";
                string CCNo = creditCard.Number.ToString();
                string maskedCCNo = String.Format("{0} {0} {0} {1}", XXNo, CCNo.Substring(CCNo.Length - 4, 4));
                row["Tarjeta"] = maskedCCNo;
                row["Vencimiento"] = creditCard.ExpiryDate;
                dataTable.Rows.Add(row);
            }
            dgvCategories.DataSource = dataTable;
        }

        private DataTable InitializeDataTable() 
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Categoría", typeof(Category));
            dataTable.Columns.Add("Nombre", typeof(CreditCard));
            dataTable.Columns.Add("Tipo", typeof(string));
            dataTable.Columns.Add("Tarjeta", typeof(string));
            dataTable.Columns.Add("Vencimiento", typeof(DateTime));
            return dataTable;
        }

        private void BtnAddCreditCard_Click(object sender, EventArgs e)
        {
            DisposeChildForm();
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            DisposeChildForm();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            CreditCard creditCardToRemove = (CreditCard)dgvCategories.SelectedRows[0].Cells[1].Value;
            this.creditCards.RemoveCreditCard(creditCardToRemove);
            LoadCategoriesList();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            DisposeChildForm();
            ChangeToMenu();
        }

        private void DisposeChildForm() 
        {
            if (this.creditCardForm != null) 
            {
                this.creditCardForm.Dispose();
            }
        }
    }
}
