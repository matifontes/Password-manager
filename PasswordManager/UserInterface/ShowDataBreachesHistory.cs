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
    public partial class ShowDataBreachesHistory : Form
    {
        const string CATEGORY_HEADER = "Categoría";
        const string SITE_HEADER = "Sitio";
        const string USER_HEADER = "Usuario";
        const string LASTMODIFICATION_DATE_HEADER = "Última Modificación";
        const string NAME_HEADER = "Nombre";
        const string TYPE_HEADER = "Tipo";
        const string CCNUMBER_HEADER = "Tarjeta";
        const string EXPIRYDATE_HEADER = "Vencimiento";
        DataBreach dBreach;
        public ShowDataBreachesHistory(DataBreach dBreach)
        {
            InitializeComponent();
            this.dBreach = dBreach;
            LoadListPasswords();
            LoadCreditCardsList();
        }

        private void LoadListPasswords()
        {
            DataTable dataTable = InitializeTablePassword();
            foreach (Password password in this.dBreach.passwords)
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
            List<CreditCard> orderedCreditCard = this.dBreach.creditCards;
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
            dgvCreditCards.DataSource = dataTable;
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
    }
}
