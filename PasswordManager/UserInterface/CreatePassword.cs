using System;
using System.Windows.Forms;

namespace UserInterface
{
    public delegate void HandlePasswordCreation();
    public partial class CreatePassword : UserControl
    {
        private event HandlePasswordCreation CreatePasswordEvent;
        public CreatePassword()
        {
            InitializeComponent();
        }

        public void AddListener(HandlePasswordCreation del) 
        {
            CreatePasswordEvent += del;
        }
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            CreatePasswordEvent();
        }
    }
}
