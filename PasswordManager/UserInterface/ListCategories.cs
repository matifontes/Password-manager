using System;
using System.Windows.Forms;

namespace UserInterface
{
    public partial class ListCategoriesPanel : UserControl
    {
        private event HandleBackToMenu ChangeToMenu;
        public ListCategoriesPanel()
        {
            InitializeComponent();
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
