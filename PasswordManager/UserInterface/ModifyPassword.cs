using System;
using System.Windows.Forms;

namespace UserInterface
{
    public delegate void HandlePasswordModification();
    public partial class ModifyPassword : UserControl
    {
        private event HandlePasswordModification ModifyPasswordEvent;
        public ModifyPassword()
        {
            InitializeComponent();
        }

        public void AddListener(HandlePasswordModification del) 
        {
            ModifyPasswordEvent += del;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            ModifyPasswordEvent();
        }
    }
}
