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
using PasswordManager.Controllers;

namespace UserInterface
{
    public partial class ListCreditCards : UserControl
    {
        private event HandleBackToMenu ChangeToMenu;
        public ListCreditCards()
        {
            InitializeComponent();
        }

        public void AddListener(HandleBackToMenu del) 
        {
            ChangeToMenu += del;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            ChangeToMenu();
        }
    }
}
