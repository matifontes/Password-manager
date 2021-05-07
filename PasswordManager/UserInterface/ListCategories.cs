using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PasswordManager;

namespace UserInterface
{
    public partial class ListCategoriesPanel : UserControl
    {
        private event HandleBackToMenu ChangeToMenu;
        private CategoriesController categories;
        public ListCategoriesPanel(CategoriesController categories)
        {
            InitializeComponent();
            this.categories = categories;
            //Categorys Added Hardcoded
            this.categories.AddCategory(new Category("Personal"));
            this.categories.AddCategory(new Category("Trabajo"));
            this.categories.AddCategory(new Category("Gaming"));
        }

        public void AddListener(HandleBackToMenu del) 
        {
            ChangeToMenu += del;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {

        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            ChangeToMenu();
        }

        private void ListCategoriesPanel_Load(object sender, EventArgs e)
        {
            lbxCategories.DataSource = this.categories.ListCategories();
        }
    }
}
