﻿using PasswordManager;
using System;
using System.Windows.Forms;

namespace UserInterface
{
    public delegate void HandleModification();
    public partial class ListCategoriesPanel : UserControl
    {
        private event HandleBackToMenu ChangeToMenu;
        private CategoriesController categories;
        private CreateModifyCategory categoryForm;
        public ListCategoriesPanel(CategoriesController categories)
        {
            InitializeComponent();
            this.categories = categories;
            EnableOptions();
            LoadCategoriesList();
        }

        public void AddListener(HandleBackToMenu del) 
        {
            ChangeToMenu += del;
        }

        private void EnableOptions() 
        {
            if (categories.IsEmpty()) 
            {
                btnModify.Enabled = false;
            }
            else 
            {
                btnModify.Enabled = true;
            }
        }

        private void LoadCategoriesList()
        {
            lbxCategories.DataSource = this.categories.ListCategories();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            RemoveChildForms();
            CreateModifyCategoryForm();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            RemoveChildForms();
            Object category = lbxCategories.SelectedItem;
            CreateModifyCategoryForm((Category)category);
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            RemoveChildForms();
            ChangeToMenu();
        }

        private void CreateModifyCategoryForm() 
        {
            categoryForm = new CreateModifyCategory(categories, PostModification);
            categoryForm.Show();
        }

        private void CreateModifyCategoryForm(Category category)
        {
            categoryForm = new CreateModifyCategory(categories, category, PostModification);
            categoryForm.Show();
        }

        private void PostModification() 
        {
            EnableOptions();
            LoadCategoriesList();
        }

        private void RemoveChildForms() 
        {
            if (categoryForm != null)
            {
                categoryForm.Dispose();
            }
        }
    }
}
