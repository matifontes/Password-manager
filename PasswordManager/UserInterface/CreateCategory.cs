using System;
using System.Windows.Forms;
using PasswordManager.Controllers;
using PasswordManager;

namespace UserInterface
{
    public partial class CreateCategory : UserControl
    {
        private event HandleModification PostCreated;
        private CategoriesController categories;
        private ProfileController profile;
        public CreateCategory(CategoriesController categories, ProfileController profile)
        {
            InitializeComponent();
            this.categories = categories;
            this.profile = profile;
        }

        public void AddListener(HandleModification del) 
        {
            PostCreated += del;
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            const string CATEGORY_CREATED_SUCCESFULLY = "Categoria creada con exito";
            try 
            {
                categories.AddCategory(new Category(txtCategoryName.Text));
                ShowFeedbackMessage(System.Drawing.Color.Green, CATEGORY_CREATED_SUCCESFULLY);
                PostCreated();
            }
            catch (Exception exp) 
            {
                ShowFeedbackMessage(System.Drawing.Color.Red, exp.Message);
            }
        }

        private void ShowFeedbackMessage(System.Drawing.Color color, string message)
        {
            lblErrorMsg.ForeColor = color;
            lblErrorMsg.Text = message;
        }
    }
}
