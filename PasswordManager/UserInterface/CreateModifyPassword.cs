﻿using System;
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
                passwords.AddPassword(new Password((Category)cbxCategories.SelectedItem, txtPassword.Text, txtSite.Text, txtUser.Text, txtNote.Text));
                PostModification();
            }
            catch (Exception e) 
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = e.Message;
            }
                
        }

        private void ModifyPasswordEvent() 
        {
            PostModification();
        }

        private void BtnAutoGenerate_Click(object sender, EventArgs e)
        {
            int large = Convert.ToInt32(nudLarge.Value);
            GeneratePasswordSettings settings = new GeneratePasswordSettings(large,cbxMinus.Checked,cbxMayus.Checked,cbxDigits.Checked,cbxSpecialChar.Checked);
            string password = PasswordGenerator.GeneratePassword(settings);
            txtPassword.Text = password;
        }
    }
}
