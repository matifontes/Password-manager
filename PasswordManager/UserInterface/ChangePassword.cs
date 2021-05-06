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
    public partial class ChangePassword : UserControl
    {
        private event HandleBackToMenu ChangeToMenu;
        public ChangePassword()
        {
            InitializeComponent();
        }

        public void AddListener(HandleBackToMenu del) 
        {
            ChangeToMenu += del;
        }

        private void BtnChangePassword_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            const string DIALOG_MSG = "Esta seguro de cancelar?";
            const string DIALOG_ACTION = "Cancelar cambio de contraseña";
            if (ConfirmDialog(DIALOG_MSG, DIALOG_ACTION)) 
            {
                ChangeToMenu();
            }
        }

        private bool ConfirmDialog(string message, string action) 
        {
            DialogResult confirmDialog = MessageBox.Show(message, action, MessageBoxButtons.YesNo);
            return confirmDialog == DialogResult.Yes;
        }
    }
}
