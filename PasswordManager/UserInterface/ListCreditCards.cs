using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using PasswordManager;
using PasswordManager.Controllers;
using PasswordManagerDataLeyer.RepositoriesDB;

namespace UserInterface
{
    public partial class ListCreditCards : UserControl
    {
        const string CATEGORY_HEADER = "Categoría";
        const string NAME_HEADER = "Nombre";
        const string TYPE_HEADER = "Tipo";
        const string CCNUMBER_HEADER = "Tarjeta";
        const string EXPIRYDATE_HEADER = "Vencimiento";
        private CreditCardRepository creditCards;
        private ProfileController profile;
        private CategoryRepository categories;
        private CreateModifyCreditCard creditCardForm;
        private event HandleBackToMenu ChangeToMenu;
        private ShowCreditCard showCreditCard;
        public ListCreditCards(ProfileController profile)
        {
            InitializeComponent();
            this.profile = profile;
            this.creditCards = new CreditCardRepository(profile.GetProfile());
            this.categories = new CategoryRepository(profile.GetProfile());
            EnableOption();
            LoadCreditCardsList();
        }

        public void AddListener(HandleBackToMenu del) 
        {
            ChangeToMenu += del;
        }

        private void EnableOption() 
        {
            if (this.creditCards.IsEmpty() && this.categories.IsEmpty())
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
            List<CreditCard> orderedCreditCard = (List<CreditCard>)this.creditCards.GetAllByProfile(this.profile.GetId());
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
                row[EXPIRYDATE_HEADER] = creditCard.ExpiryDate.ToString("MM/yy");
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
            dataTable.Columns.Add(EXPIRYDATE_HEADER, typeof(string));
            return dataTable;
        }

        private void BtnAddCreditCard_Click(object sender, EventArgs e)
        {
            DisposeChildForm();
            CreateModifyCreditCard createCreditCard = new CreateModifyCreditCard(this.categories,this.creditCards, this.profile);
            createCreditCard.AddListener(PostModification);
            this.creditCardForm = createCreditCard;
            this.creditCardForm.Show();
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            DisposeChildForm();
            CreditCard creditCard = (CreditCard)dgvCategories.SelectedRows[0].Cells[1].Value;
            CreateModifyCreditCard modifyCreditCard = new CreateModifyCreditCard(this.categories, this.creditCards,creditCard, this.profile);
            modifyCreditCard.AddListener(PostModification);
            this.creditCardForm = modifyCreditCard;
            this.creditCardForm.Show();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {

            CreditCard creditCard = (CreditCard)dgvCategories.SelectedRows[0].Cells[1].Value;
            if (creditCard != null) 
            {
                DisposeChildForm();
                this.showCreditCard = new ShowCreditCard(creditCard);
                this.showCreditCard.Show();
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            CreditCard creditCardToRemove = (CreditCard)dgvCategories.SelectedRows[0].Cells[1].Value;
            if (creditCardToRemove != null) 
            {
                DisposeChildForm();
                this.creditCards.Delete(creditCardToRemove.Id);
                PostModification();
            }
        }

        private void PostModification() 
        {
            EnableOption();
            LoadCreditCardsList();
            DisposeChildForm();
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

            if (this.showCreditCard != null) 
            {
                this.showCreditCard.Dispose();
            }
        }
    }
}
