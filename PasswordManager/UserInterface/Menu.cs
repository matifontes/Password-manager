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
    public delegate void HandleWindowChange(UserControl panel);
    public partial class MenuPanel : UserControl
    {
        private SystemProfile profile;
        private event HandleWindowChange WindowChange;
        public MenuPanel(SystemProfile profile)
        {
            InitializeComponent();
            this.profile = profile;
        }

        public void AddListener(HandleWindowChange del) 
        {
            WindowChange += del;
        }

        private void BtnCategories_Click(object sender, EventArgs e)
        {
            ListCategoriesPanel categories = new ListCategoriesPanel();
            WindowChange(categories);
        }

        private void BtnPasswords_Click(object sender, EventArgs e)
        {
            ListPasswordsPanel passwords = new ListPasswordsPanel();
            WindowChange(passwords);
        }

        private void BtnCreditCards_Click(object sender, EventArgs e)
        {
            ListCreditCards creditCards = new ListCreditCards();
            WindowChange(creditCards);
        }

        private void BtnBreaches_Click(object sender, EventArgs e)
        {

        }

    }
}
