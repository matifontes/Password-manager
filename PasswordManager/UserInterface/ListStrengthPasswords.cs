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
    public partial class ListStrengthPasswords : UserControl
    {
        private PasswordsController passwords;
        private CategoriesController categories;
        private event HandleBackToMenu ChangeToMenu;
        private CreateModifyPassword passwordForm;
        private List<Password> passList;
        private string strength;
        public ListStrengthPasswords(PasswordsController passwords, CategoriesController categories, List<Password> list, string strength)
        {
            InitializeComponent();
            this.categories = categories;
            this.passwords = passwords;
            this.passList = list;
            this.strength = strength;
            EnableOptions();
            LoadTitle();
            LoadListPasswords();
        }

        public void AddListener(HandleBackToMenu del)
        {
            ChangeToMenu += del;
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
            if (this.passwords.IsEmpty() && this.categories.IsEmpty())
            {
                btnModify.Enabled = false;
            }
            else if (this.passwords.IsEmpty() && !this.categories.IsEmpty())
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
                row["Categoría"] = password.Category;
                row["Sitio"] = password.Site;
                row["Usuario"] = password;
                row["Última Modificación"] = password.LastModificationDate;
                dataTable.Rows.Add(row);
            }

            dgvList.DataSource = dataTable;
        }


        private DataTable InitializeTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Categoría", typeof(object));
            dataTable.Columns.Add("Sitio", typeof(string));
            dataTable.Columns.Add("Usuario", typeof(Password));
            dataTable.Columns.Add("Última Modificación", typeof(DateTime));
            return dataTable;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            DisposeChildForms();
            Password password = (Password)dgvList.SelectedRows[0].Cells[2].Value;
            this.passwordForm = new CreateModifyPassword(this.passwords, this.categories, password);
            passwordForm.AddListener(PostModification);
            passwordForm.Show();
        }

        private void PostModification()
        {
            EnableOptions();
            LoadListPasswords();
        }

        private void btnBack_Click(object sender, EventArgs e)
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
