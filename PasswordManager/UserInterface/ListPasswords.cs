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
    public delegate void HandlePostModification();
    public partial class ListPasswordsPanel : UserControl
    {
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
            }
            else if (this.passwords.IsEmpty() && !this.categories.IsEmpty())
            {
                btnModify.Enabled = false;
                btnRemove.Enabled = false;
                btnAddPassword.Enabled = true;
            }
            else 
            {
                btnRemove.Enabled = true;
                btnModify.Enabled = true;
                btnAddPassword.Enabled = true;
            }
        }

        private void LoadListPasswords() 
        {
            List<Password> orderedPasswords = passwords.ListPasswords();
            DataTable dataTable = InitilizeTable();

            foreach (Password password in orderedPasswords) 
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

        private DataTable InitilizeTable() 
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Categoría", typeof(object));
            dataTable.Columns.Add("Sitio", typeof(string));
            dataTable.Columns.Add("Usuario", typeof(Password));
            dataTable.Columns.Add("Última Modificación", typeof(DateTime));
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
            this.passwordForm = new CreateModifyPassword(this.passwords, this.categories, password);
            passwordForm.AddListener(PostModification);
            passwordForm.Show();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            Password selectedPassword = (Password)dgvPasswords.SelectedRows[0].Cells[2].Value;
            if (selectedPassword != null) 
            {
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
