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
using PasswordManager;


namespace UserInterface
{
    public partial class DataBreachesHistory : UserControl
    {
        private DataBreachesController dBreachesController;
        private event HandleBackToMenu ChangeToMenu;
        private event HandleWindowChange ChangeWindow;
        public DataBreachesHistory(DataBreachesController dBreachesController)
        {
            InitializeComponent();
            this.dBreachesController = dBreachesController;
        }

        public void AddListener(HandleBackToMenu del)
        {
            ChangeToMenu += del;
        }

    }
}
