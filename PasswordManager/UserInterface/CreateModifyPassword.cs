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
    public partial class CreateModifyPassword : Form
    {
        private PasswordsController passwords;
        private CategoriesController categories;
        private event HandlePostModification PostModification;
        private Password password;
        public CreateModifyPassword(PasswordsController passwords, CategoriesController categories)
        {
            InitializeComponent();
            CreatePasswordPanel();
            this.passwords = passwords;
            this.categories = categories;
            LoadCategories();
        }
        public CreateModifyPassword(PasswordsController passwords, CategoriesController categories, Password password) 
        {
            InitializeComponent();
            CreateModifyPanel();
            this.passwords = passwords;
            this.categories = categories;
            this.password = password;
            LoadCategories();
            LoadPasswordOnFields();
        }

        public void AddListener(HandlePostModification del) 
        {
            PostModification += del;
        }

        private void LoadCategories() 
        {
            foreach (Category category in categories.ListCategories()) 
            {
                cbxCategories.Items.Add(category);
            }
            cbxCategories.SelectedIndex = 0;
        }

        private void LoadPasswordOnFields() 
        {
            for (int i = 0; i < cbxCategories.Items.Count; i++) 
            {
                if (cbxCategories.Items[i].ToString() == password.Category.ToString()) 
                {
                    cbxCategories.SelectedItem = cbxCategories.Items[i];
                }
            }
            txtSite.Text = this.password.Site;
            txtUser.Text = this.password.User;
            txtNote.Text = this.password.Note;
            txtPassword.Text = this.password.Pass;
        }

        private void CreateModifyPanel() 
        {
            ModifyPassword modifyPassword = new ModifyPassword();
            modifyPassword.AddListener(ModifyPasswordEvent);
            operationPanel.Controls.Add(modifyPassword);
        }

        private void CreatePasswordPanel() 
        {
            CreatePassword createPassword = new CreatePassword();
            createPassword.AddListener(CreatePasswordEvent);
            operationPanel.Controls.Add(createPassword);
        }

        private void CreatePasswordEvent() 
        {
            try
            {
                const string SUCCESSFUL_MSG = "Contraseña creada con exito";
                passwords.AddPassword(new Password((Category)cbxCategories.SelectedItem, txtPassword.Text, txtSite.Text, txtUser.Text, txtNote.Text));
                ShowMSG(System.Drawing.Color.Green, SUCCESSFUL_MSG);
                PostModification();
            }
            catch (Exception e) 
            {
                ShowMSG(System.Drawing.Color.Red,e.Message);
            }
                
        }

        private void ModifyPasswordEvent() 
        {
            try
            {
                const string SUCCESSFUL_MSG = "Contraseña modificada con exito";
                password.Category = (Category)cbxCategories.SelectedItem;
                password.Site = txtSite.Text;
                password.User = txtUser.Text;
                password.Pass = txtPassword.Text;
                password.Note = txtNote.Text;
                ShowMSG(System.Drawing.Color.Green, SUCCESSFUL_MSG);
                PostModification();
            }
            catch (Exception e) 
            {
                ShowMSG(System.Drawing.Color.Red,e.Message);
            }
        }

        private void ShowMSG(System.Drawing.Color color, string message)
        {
            lblMsg.ForeColor = color;
            lblMsg.Text = message;
        }

        private void BtnAutoGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                int large = Convert.ToInt32(nudLarge.Value);
                GeneratePasswordSettings settings = new GeneratePasswordSettings(large, cbxMinus.Checked, cbxMayus.Checked, cbxDigits.Checked, cbxSpecialChar.Checked);
                string password = PasswordGenerator.GeneratePassword(settings);
                txtPassword.Text = password;
            }
            catch (Exception) 
            {
                lblAutoGenerateError.ForeColor = System.Drawing.Color.Red;
                lblAutoGenerateError.Text = "Ninguna opcion elegida";
            }
        }

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private void BtnShow_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
            timer.Interval = 30000;
            timer.Tick += new EventHandler(HidePassword);
            timer.Start();
        }

        private void HidePassword(object sender, EventArgs e) 
        {
            txtPassword.UseSystemPasswordChar = true;
        }
    }
}
