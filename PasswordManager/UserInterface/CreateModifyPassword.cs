using System;
using System.Windows.Forms;
using PasswordManager;
using PasswordManager.Controllers;
using PasswordManager.Exceptions;
using PasswordManagerDataLeyer.RepositoriesDB;

namespace UserInterface
{
    public partial class CreateModifyPassword : Form
    {
        private PasswordRepository passwords;
        private CategoryRepository categories;
        private ProfileController profile;
        private event HandlePostModification PostModification;
        private Password password;
        public CreateModifyPassword(PasswordRepository passwords, CategoryRepository categories, ProfileController profile)
        {
            InitializeComponent();
            CreatePasswordPanel();
            this.passwords = passwords;
            this.categories = categories;
            this.profile = profile;
            LoadCategories();
        }

        public CreateModifyPassword(PasswordRepository passwords, CategoryRepository categories, Password password) 
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
            foreach (Category category in categories.GetAll()) 
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
                passwords.Add(new Password((Category)cbxCategories.SelectedItem, txtPassword.Text, txtSite.Text, txtUser.Text, txtNote.Text));
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
                this.passwords.Update(password);
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
                PasswordSettings settings = new PasswordSettings(large, cbxMinus.Checked, cbxMayus.Checked, cbxDigits.Checked, cbxSpecialChar.Checked);
                string password = PasswordGenerator.GeneratePassword(settings);
                txtPassword.Text = password;
            }
            catch (Exception) 
            {
                const string AUTOGEN_MSG_ERR = "Ninguna opcion elegida";
                lblAutoGenerateError.ForeColor = System.Drawing.Color.Red;
                lblAutoGenerateError.Text = AUTOGEN_MSG_ERR;
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
