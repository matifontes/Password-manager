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
using PasswordManager.Exceptions;

namespace UserInterface
{
    public partial class ModifyCategory : UserControl
    {
        private Category category;
        private event HandleModification PostModified;
        public ModifyCategory(Category category)
        {
            InitializeComponent();
            this.category = category;
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
                category.ChangeName(txtCategoryName.Text);
                ShowFeedbackMessage(System.Drawing.Color.Green, MODIFY_CORRECTLY_MSG);
                PostModified();
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
