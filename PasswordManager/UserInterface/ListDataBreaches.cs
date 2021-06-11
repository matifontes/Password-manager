using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using PasswordManager.Controllers;
using PasswordManager;

namespace UserInterface
{
    public partial class ListDataBreaches : UserControl
    {
        const string CATEGORY_HEADER = "Categoría";
        const string SITE_HEADER = "Sitio";
        const string USER_HEADER = "Usuario";
        const string LASTMODIFICATION_DATE_HEADER = "Última Modificación";
        const string NAME_HEADER = "Nombre";
        const string TYPE_HEADER = "Tipo";
        const string CCNUMBER_HEADER = "Tarjeta";
        const string EXPIRYDATE_HEADER = "Vencimiento";
        private event HandleBackToMenu ChangeToDataBreach;
        private CreateModifyPassword passwordForm;
        private CategoriesController categories;
        private PasswordsController passwordsController;
        private DataBreachesController dBreachesController;
        private Password password;
        List<Password> passwords;
        List<CreditCard> creditCards;


        public ListDataBreaches(List<Password> passwords, List<CreditCard> creditCards, CategoriesController categories, PasswordsController passwordsController, DataBreachesController dBreaches)
        {
            InitializeComponent();
            this.passwordsController = passwordsController;
            this.categories = categories;
            this.passwords = passwords;
            this.creditCards = creditCards;
            this.dBreachesController = dBreaches;
            LoadListPasswords();
            LoadCreditCardsList();
            EnableModifyOption();
        }

        public void AddListener(HandleBackToMenu del)
        {
            ChangeToDataBreach += del;
        }

        private void LoadListPasswords()
        {
            DataTable dataTable = InitializeTablePassword();

            foreach (Password password in this.passwords)
            {
                DataRow row = dataTable.NewRow();
                row[CATEGORY_HEADER] = password.Category;
                row[SITE_HEADER] = password.Site;
                row[USER_HEADER] = password;
                row[LASTMODIFICATION_DATE_HEADER] = password.LastModificationDate;
                dataTable.Rows.Add(row);
            }

            dgvPasswords.DataSource = dataTable;
        }

        private DataTable InitializeTablePassword()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(CATEGORY_HEADER, typeof(object));
            dataTable.Columns.Add(SITE_HEADER, typeof(string));
            dataTable.Columns.Add(USER_HEADER, typeof(Password));
            dataTable.Columns.Add(LASTMODIFICATION_DATE_HEADER, typeof(DateTime));
            return dataTable;
        }

        private void LoadCreditCardsList()
        {
            DataTable dataTable = InitializeDataTableCreditCard();

            foreach (CreditCard creditCard in this.creditCards)
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
            dgvCreditCards.DataSource = dataTable;
        }

        private DataTable InitializeDataTableCreditCard()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(CATEGORY_HEADER, typeof(Category));
            dataTable.Columns.Add(NAME_HEADER, typeof(CreditCard));
            dataTable.Columns.Add(TYPE_HEADER, typeof(string));
            dataTable.Columns.Add(CCNUMBER_HEADER, typeof(string));
            dataTable.Columns.Add(EXPIRYDATE_HEADER, typeof(DateTime));
            return dataTable;
        }

        private void EnableModifyOption()
        {
            btnModify.Enabled = this.passwords.Count > 0;
            if (this.creditCards.Count == 0)
            {
                dgvCreditCards.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else 
            {
                dgvCreditCards.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            DisposeChildForm();
            Password password = (Password)dgvPasswords.SelectedRows[0].Cells[2].Value;
            this.password = password;
            this.passwordForm = new CreateModifyPassword(this.passwordsController, this.categories, password, this.dBreachesController);
            passwordForm.AddListener(PostModification);
            passwordForm.Show();
        }

        private void PostModification()
        {
            EnableModifyOption();
            LoadListPasswords();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            ChangeToDataBreach();
            DisposeChildForm();
        }

        private void DisposeChildForm()
        {
            if (this.passwordForm != null)
            {
                this.passwordForm.Dispose();
            }
        }

    }
}
