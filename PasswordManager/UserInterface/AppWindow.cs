﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PasswordManager.Controllers;
using PasswordManagerDataLeyer.RepositoriesDB;

namespace UserInterface
{
    public partial class AppWindow : Form
    {
        private ProfileController profile;
        private CategoriesController categories;
        private PasswordsController passwords;
        private CreditCardsController creditCards;

        public AppWindow()
        {
            InitializeComponent();
        }

        private void AppWindowLoader(object sender, EventArgs e)
        {
            ProfileRepository profileRepository = new ProfileRepository();

            if (profileRepository.IsEmpty()) 
            {
                CreateRegisterPanel();
            }
            else 
            {
                List<PasswordManager.Profile> profiles = (List<PasswordManager.Profile>)profileRepository.GetAll();
                profile = new ProfileController(profiles[0]);
                CreateLoginPanel();
            }
            /*
                if (this.profile != null)
                {
                    CreateLoginPanel();
                }
                else
                {
                    CreateRegisterPanel();
                }*/
        }

        private void CreateRegisterPanel() {
            RegisterProfile registerPanel = new RegisterProfile();
            registerPanel.AddListener(PostRegister);
            startPanel.Controls.Add(registerPanel);
            ReSizeForm(registerPanel.Width, registerPanel.Height);
        }

        private void CreateLoginPanel() {
            LoginPanel loginPanel = new LoginPanel(this.profile);
            loginPanel.AddListener(PostLogin);
            startPanel.Controls.Add(loginPanel);
            ReSizeForm(loginPanel.Width, loginPanel.Height);
        }

        private void CreateMenuPanel()
        {
            MenuPanel menuPanel = new MenuPanel(this.profile, this.categories, this.passwords, this.creditCards);
            menuPanel.AddListener(ChangeWindow);
            startPanel.Controls.Add(menuPanel);
            ReSizeForm(menuPanel.Width, menuPanel.Height);
        }

        private void ChangeWindow(UserControl panel) {
            ClearPanel();
            startPanel.Controls.Add(panel);
            ReSizeForm(panel.Width, panel.Height);
        }

        private void PostLogin() {
            ClearPanel();
            CreateMenuPanel();
        }

        private void PostRegister(ProfileController profile) {
            this.profile = profile;
            this.categories = new CategoriesController(this.profile.GetCategoryRepository());
            this.passwords = new PasswordsController(this.profile.GetPasswordRepository());
            this.creditCards = new CreditCardsController(this.profile.GetCreditCardRepository());
            ClearPanel();
            CreateLoginPanel();
        }

        private void ReSizeForm(int width, int height) {
            int BORDER_MARGIN = 20;
            startPanel.Size = new Size(width, height);
            this.Size = new Size(width + BORDER_MARGIN, height + BORDER_MARGIN);
        }

        private void ClearPanel() {
            startPanel.Controls.Clear();
        }
    }
}
