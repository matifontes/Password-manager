using System;
using System.Windows.Forms;
using PasswordManager;
using PasswordManager.Exceptions;
using PasswordManager.Controllers;

namespace UserInterface
{
    public partial class ModifyCategory : UserControl
    {
        private Category category;
        private CategoriesController categories;
        private event HandleModification PostModified;
        public ModifyCategory(Category category, CategoriesController categories)
        {
            InitializeComponent();
            this.category = category;
            this.categories = categories;
            txtCategoryName.Text = this.category.Name;
        }

        public void AddListener(HandleModification del) 
        {
            PostModified += del;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            const string MODIFY_CORRECTLY_MSG = "Categoria modificada correctamente";
            try
            {
                if (CategoryNameChangedOnTextField() && CheckForCategoryNameOnRepository()) 
                {
                    const string CATEGORY_ALREADY_EXISTS = "Existe una categoria con ese nombre";
                    throw new CategoryAlreadyExistsException(CATEGORY_ALREADY_EXISTS);
                }
                category.ChangeName(txtCategoryName.Text);
                ShowFeedbackMessage(System.Drawing.Color.Green, MODIFY_CORRECTLY_MSG);
                PostModified();
            }
            catch (Exception exp) 
            {
                ShowFeedbackMessage(System.Drawing.Color.Red, exp.Message);
            }
        }

        private bool CategoryNameChangedOnTextField() 
        {
            return txtCategoryName.Text != this.category.ToString();
        }

        private bool CheckForCategoryNameOnRepository() 
        {
            return this.categories.ContainsCategory(new Category(txtCategoryName.Text));
        }

        private void ShowFeedbackMessage(System.Drawing.Color color, string message) 
        {
            lblErrorMsg.ForeColor = color;
            lblErrorMsg.Text = message;
        }
    }
}
