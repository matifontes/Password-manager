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
    public partial class ListPasswordsPanel : UserControl
    {
        const string CATEGORY_HEADER = "Categoría";
        const string SITE_HEADER = "Sitio";
        const string USER_HEADER = "Usuario";
        const string LASTMODIFICATION_DATE_HEADER = "Última Modificación";
        private PasswordsController passwords;
        private CategoriesController categories;
        private event HandleBackToMenu ChangeToMenu;
        private CreateModifyPassword passwordForm;
        public ListPasswordsPanel(PasswordsController passwords, CategoriesController categories)
        {
            InitializeComponent();
            this.passwords = passwords;
            this.categories = categories;
            EnableOptions();
            LoadListPasswords();
        }

        public void AddListener(HandleBackToMenu del) 
        {
            ChangeToMenu += del;
        }

        private void EnableOptions() 
        {
            if (this.passwords.IsEmpty() && this.categories.IsEmpty())
            {
                btnModify.Enabled = false;
                btnAddPassword.Enabled = false;
                btnRemove.Enabled = false;
                btnShow.Enabled = false;
            }
            else if (this.passwords.IsEmpty() && !this.categories.IsEmpty())
            {
                btnModify.Enabled = false;
                btnRemove.Enabled = false;
                btnAddPassword.Enabled = true;
                btnShow.Enabled = false;
            }
            else 
            {
                btnRemove.Enabled = true;
                btnModify.Enabled = true;
                btnAddPassword.Enabled = true;
                btnShow.Enabled = true;
            }
        }

        private void LoadListPasswords() 
        {
            List<Password> orderedPasswords = passwords.ListPasswords();
            DataTable dataTable = InitializeDataTable();

            foreach (Password password in orderedPasswords) 
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

        private DataTable InitializeDataTable() 
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(CATEGORY_HEADER, typeof(object));
            dataTable.Columns.Add(SITE_HEADER, typeof(string));
            dataTable.Columns.Add(USER_HEADER, typeof(Password));
            dataTable.Columns.Add(LASTMODIFICATION_DATE_HEADER, typeof(DateTime));
            return dataTable;
        }

        private void BtnAddPassword_Click(object sender, EventArgs e)
        {
            DisposeChildForms();
            this.passwordForm = new CreateModifyPassword(this.passwords,this.categories);
            passwordForm.AddListener(PostModification);
            passwordForm.Show();
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            DisposeChildForms();
            Password password = (Password)dgvPasswords.SelectedRows[0].Cells[2].Value;
            this.passwordForm = new CreateModifyPassword(this.categories, password);
            passwordForm.AddListener(PostModification);
            passwordForm.Show();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            Password password = (Password)dgvPasswords.SelectedRows[0].Cells[2].Value;
            ShowPassword showPassword = new ShowPassword(password);
            showPassword.Show();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            Password selectedPassword = (Password)dgvPasswords.SelectedRows[0].Cells[2].Value;
            if (selectedPassword != null) 
            {
                DisposeChildForms();
                passwords.RemovePassword(selectedPassword);
                PostModification();
            }
        }

        private void PostModification() 
        {
            EnableOptions();
            LoadListPasswords();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            DisposeChildForms();
            ChangeToMenu();
        }

        private void DisposeChildForms()
        {
            if (this.passwordForm != null)
            {
                this.passwordForm.Dispose();
            }
        }
    }
}
