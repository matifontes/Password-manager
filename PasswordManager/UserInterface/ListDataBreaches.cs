using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PasswordManager.Controllers;
using PasswordManager;

namespace UserInterface
{
    public partial class ListDataBreaches : UserControl
    {
        private event HandleBackToMenu ChangeToDataBreach;
        private CreateModifyPassword passwordForm;
        private CategoriesController categories;
        private PasswordsController passwordsController;
        private Password password;
        List<Password> passwords;
        List<CreditCard> creditCards;


        public ListDataBreaches(List<Password> passwords, List<CreditCard> creditCards, CategoriesController categories, PasswordsController passwordsController)
        {
            InitializeComponent();
            this.passwordsController = passwordsController;
            this.categories = categories;
            this.passwords = passwords;
            this.creditCards = creditCards;
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
                row["Categoría"] = password.Category;
                row["Sitio"] = password.Site;
                row["Usuario"] = password;
                row["Última Modificación"] = password.LastModificationDate;
                dataTable.Rows.Add(row);
            }

            dgvPasswords.DataSource = dataTable;
        }

        private DataTable InitializeTablePassword()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Categoría", typeof(object));
            dataTable.Columns.Add("Sitio", typeof(string));
            dataTable.Columns.Add("Usuario", typeof(Password));
            dataTable.Columns.Add("Última Modificación", typeof(DateTime));
            return dataTable;
        }

        private void LoadCreditCardsList()
        {
            DataTable dataTable = InitializeDataTableCreditCard();

            foreach (CreditCard creditCard in this.creditCards)
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
            dgvCreditCards.DataSource = dataTable;
        }

        private DataTable InitializeDataTableCreditCard()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Categoría", typeof(Category));
            dataTable.Columns.Add("Nombre", typeof(CreditCard));
            dataTable.Columns.Add("Tipo", typeof(string));
            dataTable.Columns.Add("Tarjeta", typeof(string));
            dataTable.Columns.Add("Vencimiento", typeof(DateTime));
            return dataTable;
        }

        private void EnableModifyOption()
        {
            btnModify.Enabled = this.passwords.Count > 0;
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            DisposeChildForm();
            Password password = (Password)dgvPasswords.SelectedRows[0].Cells[2].Value;
            this.password = password;
            this.passwordForm = new CreateModifyPassword(this.passwordsController, this.categories, password);
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
