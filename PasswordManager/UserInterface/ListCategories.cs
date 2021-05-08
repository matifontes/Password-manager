using PasswordManager;
using System;
using System.Windows.Forms;

namespace UserInterface
{
    public delegate void HandleModification();
    public partial class ListCategoriesPanel : UserControl
    {
        private event HandleBackToMenu ChangeToMenu;
        private CategoriesController categories;
        private CreateModifyCategoryForm categoryForm;
        public ListCategoriesPanel(CategoriesController categories)
        {
            InitializeComponent();
            this.categories = categories;
            //Categories Added Hardcoded
            if (this.categories.Count() == 0) 
            {
                this.categories.AddCategory(new Category("Personal"));
                this.categories.AddCategory(new Category("Trabajo"));
                this.categories.AddCategory(new Category("Gaming"));
            }
            LoadCategoriesList();
        }

        public void AddListener(HandleBackToMenu del) 
        {
            ChangeToMenu += del;
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

        private void LoadCategoriesList() 
        {
            lbxCategories.DataSource = this.categories.ListCategories();
        }

        private void CreateModifyCategoryForm() 
        {
            categoryForm = new CreateModifyCategoryForm(categories, LoadCategoriesList);
            categoryForm.Show();
        }

        private void CreateModifyCategoryForm(Category category)
        {
            categoryForm = new CreateModifyCategoryForm(categories, category, LoadCategoriesList);
            categoryForm.Show();
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
