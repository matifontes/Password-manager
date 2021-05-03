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
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void BtnCategories_Click(object sender, EventArgs e)
        {

        }

        private void BtnPasswords_Click(object sender, EventArgs e)
        {
            Console.WriteLine("de click");
        }

        private void BtnCreditCards_Click(object sender, EventArgs e)
        {

        }

        private void BtnBreaches_Click(object sender, EventArgs e)
        {

        }
    }
}
