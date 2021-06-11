using System;
using System.Windows.Forms;
using PasswordManager.Controllers;
using PasswordManager;
using PasswordManagerDataLeyer.RepositoriesDB;

namespace UserInterface
{
    public partial class CreateCategory : UserControl
    {
        private event HandleModification PostCreated;
        private CategoryRepository categories;
        private ProfileController profile;
        public CreateCategory(CategoryRepository categories, ProfileController profile)
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
                categories.Add(new Category(txtCategoryName.Text.ToUpper()));
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
