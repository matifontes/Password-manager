using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using PasswordManager;
using PasswordManager.Controllers;
using PasswordManagerDataLeyer.RepositoriesDB;

namespace UserInterface
{
    public partial class ListPasswordsPanel : UserControl
    {
        const string CATEGORY_HEADER = "Categoría";
        const string SITE_HEADER = "Sitio";
        const string USER_HEADER = "Usuario";
        const string LASTMODIFICATION_DATE_HEADER = "Última Modificación";
        private PasswordRepository passwords;
        private CategoryRepository categories;
        private ProfileController profile;
        private event HandleBackToMenu ChangeToMenu;
        private CreateModifyPassword passwordForm;
        private ShowPassword showPassword;
        private DataBreachesController dBreaches;

        public ListPasswordsPanel(ProfileController profile, DataBreachesController dBreaches)
        {
            InitializeComponent();
            this.profile = profile;
            this.categories = new CategoryRepository(profile.GetProfile());
            this.passwords = new PasswordRepository(profile.GetProfile());
            this.dBreaches = dBreaches;
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
            List<Password> orderedPasswords = (List<Password>)passwords.GetAllByProfile(profile.GetId());
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
            this.passwordForm = new CreateModifyPassword(this.passwords,this.categories, this.profile, this.dBreaches);
            passwordForm.AddListener(PostModification);
            passwordForm.Show();
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            DisposeChildForms();
            Password password = (Password)dgvPasswords.SelectedRows[0].Cells[2].Value;
            this.passwordForm = new CreateModifyPassword(this.passwords,this.categories, password, this.dBreaches);
            passwordForm.AddListener(PostModification);
            passwordForm.Show();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            Password password = (Password)dgvPasswords.SelectedRows[0].Cells[2].Value;
            if (password != null) 
            {
                DisposeChildForms();
                this.showPassword = new ShowPassword(password);
                this.showPassword.Show();
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            Password selectedPassword = (Password)dgvPasswords.SelectedRows[0].Cells[2].Value;
            if (selectedPassword != null) 
            {
                DisposeChildForms();
                passwords.Delete(selectedPassword.Id);
                PostModification();
            }
        }

        private void PostModification() 
        {
            EnableOptions();
            LoadListPasswords();
            DisposeChildForms();
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

            if(this.showPassword != null) 
            {
                this.showPassword.Dispose();
            }
        }
    }
}
