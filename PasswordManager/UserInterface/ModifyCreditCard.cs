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
    public delegate void HandleCreditCardModification();
    public partial class ModifyCreditCard : UserControl
    {
        private event HandleCreditCardModification PostModification;
        public ModifyCreditCard()
        {
            InitializeComponent();
        }

        public void AddListener(HandleCreditCardModification del) 
        {
            PostModification += del;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            PostModification();
        }
    }
}
