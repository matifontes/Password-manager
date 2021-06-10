using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using PasswordManager.Controllers;
using PasswordManager;
using PasswordManagerDataLeyer.RepositoriesDB;

namespace UserInterface
{
    public partial class ListStrengthPasswords : UserControl
    {
        const string CATEGORY_HEADER = "Categoría";
        const string SITE_HEADER = "Sitio";
        const string USER_HEADER = "Usuario";
        const string LASTMODIFICATION_DATE_HEADER = "Última Modificación";
        private PasswordsController passwords;
        private CategoryRepository categories;
        private event HandleBackToMenu ChangeToPasswordStrenght;
        private CreateModifyPassword passwordForm;
        private List<Password> passList;
        private Password modifyPassword;
        private string strength;
        public ListStrengthPasswords(PasswordsController passwords, CategoryRepository categories, List<Password> list)
        {
            InitializeComponent();
            this.categories = categories;
            this.passList = list;
            this.strength = list[0].Strength;
            this.passwords = passwords;
            EnableOptions();
            LoadTitle();
            LoadListPasswords();
        }

        public void AddListener(HandleBackToMenu del)
        {
            ChangeToPasswordStrenght += del;
        }

        private void LoadTitle()
        {
            if(this.passList.Count > 0)
            {
                string title = "Contraseñas con fortaleza ";
                title += this.passList[0].Strength;
                lblTitle.Text = title;
            }
        }

        private void EnableOptions()
        {
            if (this.passList.Count() == 0)
            {
                btnModify.Enabled = false;
            }
            else
            {
                btnModify.Enabled = true;
            }
        }

        private void LoadListPasswords()
        {
            DataTable dataTable = InitializeTable();

            foreach (Password password in passList)
            {

                DataRow row = dataTable.NewRow();
                row[CATEGORY_HEADER] = password.Category;
                row[SITE_HEADER] = password.Site;
                row[USER_HEADER] = password;
                row[LASTMODIFICATION_DATE_HEADER] = password.LastModificationDate;
                dataTable.Rows.Add(row);
            }

            dgvList.DataSource = dataTable;
        }


        private DataTable InitializeTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(CATEGORY_HEADER, typeof(object));
            dataTable.Columns.Add(SITE_HEADER, typeof(string));
            dataTable.Columns.Add(USER_HEADER, typeof(Password));
            dataTable.Columns.Add(LASTMODIFICATION_DATE_HEADER, typeof(DateTime));
            return dataTable;
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            DisposeChildForms();
            Password password = (Password)dgvList.SelectedRows[0].Cells[2].Value;
            this.modifyPassword = password;
            this.passwordForm = new CreateModifyPassword(this.passwords,this.categories, password);
            passwordForm.AddListener(PostModification);
            passwordForm.Show();
        }

        private void PostModification()
        {
            if (this.modifyPassword.Strength != this.strength) 
            {
                const string SUCCESSFUL_MODIFY = "Contraseña modificada correctamente, a cambiado su nivel de fortaleza";
                this.passList.Remove(this.modifyPassword);
                DisposeChildForms();
                DisposeModifyPassword();
                ShowMSG(System.Drawing.Color.Green, SUCCESSFUL_MODIFY);
            }
            EnableOptions();
            LoadListPasswords();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            DisposeModifyPassword();
            DisposeChildForms();
            ChangeToPasswordStrenght();

        }

        private void ShowMSG(System.Drawing.Color color, string message) 
        {
            lblMsg.ForeColor = color;
            lblMsg.Text = message;
        }

        private void DisposeChildForms()
        {
            if (this.passwordForm != null)
            {
                this.passwordForm.Dispose();
            }
        }

        private void DisposeModifyPassword() 
        {
            if (this.modifyPassword != null) 
            {
                this.modifyPassword = null;
            }
        }
    }
}
