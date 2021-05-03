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

namespace UserInterface
{
    public partial class MenuPanel : UserControl
    {
        private SystemProfile profile;
        public MenuPanel(SystemProfile profile)
        {
            InitializeComponent();
            this.profile = profile;
        }

        private void BtnCategories_Click(object sender, EventArgs e)
        {

        }

        private void BtnPasswords_Click(object sender, EventArgs e)
        {

        }

        private void BtnCreditCards_Click(object sender, EventArgs e)
        {

        }

        private void BtnBreaches_Click(object sender, EventArgs e)
        {

        }
    }
}
