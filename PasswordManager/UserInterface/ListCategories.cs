using System;
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
    }
}
