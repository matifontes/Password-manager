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
    public delegate void HandleCreditCardCreation();
    public partial class CreateCreditCard : UserControl
    {
        private event HandleCreditCardCreation PostCreation;
        public CreateCreditCard()
        {
            InitializeComponent();
        }

        public void AddListener(HandleCreditCardCreation del) 
        {
            PostCreation += del;
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            PostCreation();
        }
    }
}
