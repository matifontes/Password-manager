using System;
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
    public partial class CreateCategory : UserControl
    {
        private event HandleModification PostCreated;
        private CategoriesController categories;
        public CreateCategory(CategoriesController categories)
        {
            InitializeComponent();
            this.categories = categories;
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
            catch (InvalidCategoryNameException exp) 
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
