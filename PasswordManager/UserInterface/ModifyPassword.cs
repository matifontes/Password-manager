using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
