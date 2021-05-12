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
        const string CATEGORY_HEADER = "Categoría";
        const string NAME_HEADER = "Nombre";
        const string TYPE_HEADER = "Tipo";
        const string CCNUMBER_HEADER = "Tarjeta";
        const string EXPIRYDATE_HEADER = "Vencimiento";
        private CreditCardsController creditCards;
        private CategoriesController categories;
        private CreateModifyCreditCard creditCardForm;
        private event HandleBackToMenu ChangeToMenu;
        public ListCreditCards(CreditCardsController creditCards, CategoriesController categories)
        {
            InitializeComponent();
            this.creditCards = creditCards;
            this.categories = categories;
            EnableOption();
            LoadCreditCardsList();
        }

        public void AddListener(HandleBackToMenu del) 
        {
            ChangeToMenu += del;
        }

        private void EnableOption() 
        {
            if (creditCards.IsEmpty() && categories.IsEmpty())
            {
                btnModify.Enabled = false;
                btnRemove.Enabled = false;
                btnAddCreditCard.Enabled = false;
                dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                btnShow.Enabled = false;
            }
            else if (creditCards.IsEmpty() && !categories.IsEmpty())
            {
                btnModify.Enabled = false;
                btnRemove.Enabled = false;
                btnAddCreditCard.Enabled = true;
                dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                btnShow.Enabled = false;
            }
            else 
            {
                btnModify.Enabled = true;
                btnRemove.Enabled = true;
                btnAddCreditCard.Enabled = true;
                dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                btnShow.Enabled = true;
            }
        }

        private void LoadCreditCardsList() 
        {
            List<CreditCard> orderedCreditCard = this.creditCards.ListCreditCards();
            DataTable dataTable = InitializeDataTable();

            foreach (CreditCard creditCard in orderedCreditCard)
            {
                DataRow row = dataTable.NewRow();
                row[CATEGORY_HEADER] = creditCard.Category;
                row[NAME_HEADER] = creditCard;
                row[TYPE_HEADER] = creditCard.Type;
                string XXNo = "XXXX";
                string CCNo = creditCard.Number.ToString();
                string maskedCCNo = String.Format("{0} {0} {0} {1}", XXNo, CCNo.Substring(CCNo.Length - 4, 4));
                row[CCNUMBER_HEADER] = maskedCCNo;
                row[EXPIRYDATE_HEADER] = creditCard.ExpiryDate;
                dataTable.Rows.Add(row);
            }
            dgvCategories.DataSource = dataTable;
        }

        private DataTable InitializeDataTable() 
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(CATEGORY_HEADER, typeof(Category));
            dataTable.Columns.Add(NAME_HEADER, typeof(CreditCard));
            dataTable.Columns.Add(TYPE_HEADER, typeof(string));
            dataTable.Columns.Add(CCNUMBER_HEADER, typeof(string));
            dataTable.Columns.Add(EXPIRYDATE_HEADER, typeof(DateTime));
            return dataTable;
        }

        private void BtnAddCreditCard_Click(object sender, EventArgs e)
        {
            DisposeChildForm();
            CreateModifyCreditCard createCreditCard = new CreateModifyCreditCard(this.categories,this.creditCards);
            createCreditCard.AddListener(PostModification);
            this.creditCardForm = createCreditCard;
            this.creditCardForm.Show();
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            DisposeChildForm();
            CreditCard creditCard = (CreditCard)dgvCategories.SelectedRows[0].Cells[1].Value;
            CreateModifyCreditCard modifyCreditCard = new CreateModifyCreditCard(this.categories, this.creditCards,creditCard);
            modifyCreditCard.AddListener(PostModification);
            this.creditCardForm = modifyCreditCard;
            this.creditCardForm.Show();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {

            CreditCard creditCard = (CreditCard)dgvCategories.SelectedRows[0].Cells[1].Value;
            if (creditCard != null) 
            {
                ShowCreditCard creditCardShow = new ShowCreditCard(creditCard);
                creditCardShow.Show();
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            CreditCard creditCardToRemove = (CreditCard)dgvCategories.SelectedRows[0].Cells[1].Value;
            if (creditCardToRemove != null) 
            {
                DisposeChildForm();
                this.creditCards.RemoveCreditCard(creditCardToRemove);
                PostModification();
            }
        }

        private void PostModification() 
        {
            EnableOption();
            LoadCreditCardsList();
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
