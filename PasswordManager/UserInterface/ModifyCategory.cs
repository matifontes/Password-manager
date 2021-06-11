using System;
using System.Windows.Forms;
using PasswordManager;
using PasswordManager.Exceptions;
using PasswordManager.Controllers;
using PasswordManagerDataLeyer.RepositoriesDB;

namespace UserInterface
{
    public partial class ModifyCategory : UserControl
    {
        private Category category;
        private CategoryRepository categories;
        private event HandleModification PostModified;
        public ModifyCategory(Category category, CategoryRepository categories)
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
                category.ChangeName(txtCategoryName.Text.ToUpper());
                categories.Update(category);
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

        private void ShowFeedbackMessage(System.Drawing.Color color, string message) 
        {
            lblErrorMsg.ForeColor = color;
            lblErrorMsg.Text = message;
        }
    }
}
