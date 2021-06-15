using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PasswordManager;
using PasswordManager.Controllers;
using PasswordManager.Exceptions;
using PasswordManagerDataLeyer.RepositoriesDB;

namespace UserInterface
{
    public partial class CreateModifyPassword : Form
    {
        const string LIGHTGREEN_STRENGTH = "LightGreen";
        const string DARKGREEN_STRENGTH = "DarkGreen";
        const string RED_STRENGTH = "Red";
        const string ORANGE_STRENGTH = "Orange";
        const string YELLOW_STRENGTH = "Yellow";
        private PasswordRepository passwords;
        private CategoryRepository categories;
        private ProfileController profile;
        private event HandlePostModification PostModification;
        private Password password;
		private DataBreachRepository dataBreach;

        public CreateModifyPassword(PasswordRepository passwords, CategoryRepository categories, ProfileController profile, DataBreachRepository dataBreach)
        {
            InitializeComponent();
            CreatePasswordPanel();
            this.passwords = passwords;
            this.categories = categories;
			this.dataBreach = dataBreach;
            this.profile = profile;
            LoadCategories();
        }

        public CreateModifyPassword(PasswordRepository passwords, CategoryRepository categories, Password password, DataBreachRepository dataBreach) 
        {
            InitializeComponent();
            CreateModifyPanel();
            this.passwords = passwords;
            this.categories = categories;
            this.password = password;
            this.dataBreach = dataBreach;
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
            Password pass = new Password((Category)cbxCategories.SelectedItem, txtPassword.Text, txtSite.Text, txtUser.Text, txtNote.Text);

            String msg = SuggestPasswordImprovement(pass);
            const string DIALOG_ACTION = "Crear contraseña";
            
            if (ConfirmDialog(msg, DIALOG_ACTION))
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
                    ShowMSG(System.Drawing.Color.Red, e.Message);
                }
            }     
        }

        private void ModifyPasswordEvent() 
        {
            Password pass = new Password((Category)cbxCategories.SelectedItem, txtPassword.Text, txtSite.Text, txtUser.Text, txtNote.Text);
           
            String msg = SuggestPasswordImprovement(pass);
            const string DIALOG_ACTION = "Cambiar de contraseña";

            if (ConfirmDialog(msg, DIALOG_ACTION)) {
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

                    PostModification();
                }
                catch (Exception e)
                {
                    ShowMSG(System.Drawing.Color.Red, e.Message);
                }
            }
           
        }

        public String SuggestPasswordImprovement(Password pass)
        {
            String suggestPasswordString = "";
            suggestPasswordString += PasswordExistsOnDataBreaches(pass);
            suggestPasswordString += Environment.NewLine;
            suggestPasswordString += DuplicatePassword(pass);
            suggestPasswordString += Environment.NewLine;
            suggestPasswordString += SafePassword(pass);

            return suggestPasswordString;

        }

        private String PasswordExistsOnDataBreaches(Password pass)
        {
            String passwordExist = "";
            if (this.dataBreach.PasswordExistsOnDataBreach(pass))
            {
                passwordExist = "La contraseña aparece en un data breach conocido";
            }
            else
            {
                passwordExist = "No aparece en un data breach conocido";
            }
            return passwordExist;
        }

        private String DuplicatePassword(Password pass)
        {
            String duplicatePasswordResult = "";
            List<Password> passwordsWithSameUserAndPass = (List<Password>)this.passwords.GetAllWithSamePasswordAndUser(pass);
            if (passwordsWithSameUserAndPass.Count > 0)
            {
                duplicatePasswordResult = "El mismo usuario ya tiene una contraseña igual";
            }
            else
            {
                duplicatePasswordResult = "El usuario no tiene ninguna contraseña igual";
            }
            return duplicatePasswordResult;
        }

        private String SafePassword(Password pass)
        {
            String safePasswordResult = "";
            if (pass.Strength == LIGHTGREEN_STRENGTH || pass.Strength == DARKGREEN_STRENGTH)
            {
                safePasswordResult = "La contraseña es segura, fortaleza: " + StrengthPasswordString(pass.Strength);
            }
            else
            {
                safePasswordResult = "La contraseña no es segura, fortaleza: " + StrengthPasswordString(pass.Strength);
            }
            return safePasswordResult;
        }

        private String StrengthPasswordString(string passStrength)
        {
            string strength = "";
           
            if (passStrength == LIGHTGREEN_STRENGTH)
            {
                strength = "Verde claro";
            }
            else if(passStrength == DARKGREEN_STRENGTH)
            {
                strength = "Verde oscuro";
            }
            else if(passStrength == ORANGE_STRENGTH)
            {
                strength = "Naranja";
            }
            else if(passStrength == RED_STRENGTH)
            {
                strength = "Rojo";
            }
            else
            {
                strength = "Amarillo";
            }

            return strength;
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

        private bool ConfirmDialog(string message, string action)
        {
            DialogResult confirmDialog = MessageBox.Show(message, action, MessageBoxButtons.YesNo);
            return confirmDialog == DialogResult.Yes;
        }
    }
}
