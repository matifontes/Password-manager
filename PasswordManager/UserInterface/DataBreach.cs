using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PasswordManager.Controllers;

namespace UserInterface
{
    public partial class DataBreach : UserControl
    {
        private PasswordsController passwords;
        private event HandleBackToMenu ChangeToMenu;
        private CreateModifyPassword passwordForm;
        public DataBreach(PasswordsController passwords)
        {
            InitializeComponent();
            this.passwords = passwords;
        }

        public void AddListener(HandleBackToMenu del)
        {
            ChangeToMenu += del;
        }
    }
}
