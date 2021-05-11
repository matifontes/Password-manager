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
        private CategoriesController categories;
        private event HandleBackToMenu ChangeToPasswordStrenght;
        private CreateModifyPassword passwordForm;
        private List<Password> passList;
        private Password modifyPassword;
        private string strength;
        public ListStrengthPasswords( CategoriesController categories, List<Password> list, string strength)
        {
            InitializeComponent();
            this.categories = categories;
            this.passList = list;
            this.strength = strength;
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

        private void BtnModify_Click(object sender, EventArgs e)
        {
            DisposeModifyPassword();
            DisposeChildForms();
            Password password = (Password)dgvList.SelectedRows[0].Cells[2].Value;
            this.modifyPassword = password;
            this.passwordForm = new CreateModifyPassword(this.categories, password);
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
                ShowMSG(System.Drawing.Color.Green, SUCCESSFUL_MODIFY);
            }
            DisposeModifyPassword();
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
