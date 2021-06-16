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
using PasswordManagerDataLeyer.RepositoriesDB;

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
        const string PASSWORD_CHANGED = "Cambio la contraseña";
        private DataBreach dBreach;
        private ProfileController profile;
        private CreateModifyPassword modifyPassword;
        public ShowDataBreachesHistory(ProfileController profile, DataBreach dBreach)
        {
            InitializeComponent();
            this.profile = profile;
            this.dBreach = dBreach;
            if(dBreach.passwords.Count > 0)
            {
                btnModify.Enabled = true;
            }
            else
            {
                btnModify.Enabled = false;
            }
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
                if(password.LastPasswordChange > this.dBreach.Date) 
                {
                    row[PASSWORD_CHANGED] = "Si";
                }
                else 
                {
                    row[PASSWORD_CHANGED] = "No";
                }
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
            dataTable.Columns.Add(PASSWORD_CHANGED, typeof(string));
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

        private void btnModify_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if ((string)dgvPasswords.SelectedRows[0].Cells[4].Value == "Si") 
            {
                const string PASSWORD_ALREADY_CHANGED = "La contraseña ya fue modificada";
                ShowMSG(System.Drawing.Color.Red, PASSWORD_ALREADY_CHANGED);
            }
            else 
            {
                DisposeChildForm();
                Password password = (Password) dgvPasswords.SelectedRows[0].Cells[2].Value;
                this.modifyPassword = new CreateModifyPassword(new PasswordRepository(this.profile.GetProfile()),new CategoryRepository(this.profile.GetProfile()), password, new DataBreachRepository(this.profile.GetProfile()));
                this.modifyPassword.AddListener(PostModification);
                this.modifyPassword.Show();
            }
        }
        
        private void PostModification() 
        {
            LoadListPasswords();
            DisposeChildForm();
            const string PASSWORD_MODIFIED = "La contraseña se a modificado";
            ShowMSG(System.Drawing.Color.Green, PASSWORD_MODIFIED);
        }

        private void ShowMSG(System.Drawing.Color color, string msg) 
        {
            lblMsg.Text = msg;
            lblMsg.ForeColor = color;
        }

        private void DisposeChildForm() 
        {
            if(this.modifyPassword != null) 
            {
                this.modifyPassword.Dispose();
            }
        }
    }
}
