using System;
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
