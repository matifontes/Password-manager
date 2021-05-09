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
    public partial class ListPasswordsPanel : UserControl
    {
        private PasswordsController passwords;
        private event HandleBackToMenu ChangeToMenu;
        public ListPasswordsPanel(PasswordsController passwords)
        {
            InitializeComponent();
            this.passwords = passwords;
            //hardcoded passwords
            if (passwords.Count() == 0) 
            {
                passwords.AddPassword(new Password(new Category("Personal"), "admin", "sitioweb", "administrador", ""));
                passwords.AddPassword(new Password(new Category("Trabajo"), "admin", "sitioweb", "administrador", ""));
                passwords.AddPassword(new Password(new Category("Gaming"), "admin", "sitioweb", "administrador", ""));
            }

            LoadListPasswords();
        }

        public void AddListener(HandleBackToMenu del) 
        {
            ChangeToMenu += del;
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

        }

        private void BtnModify_Click(object sender, EventArgs e)
        {

        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            Password selectedPassword = (Password)dgvPasswords.SelectedRows[0].Cells[2].Value;
            if (selectedPassword != null) 
            {
                passwords.RemovePassword(selectedPassword);
                LoadListPasswords();
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            ChangeToMenu();
        }
    }
}
