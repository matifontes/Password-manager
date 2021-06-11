using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using PasswordManager;
using PasswordManager.Controllers;

namespace UserInterface
{
    public partial class DataBreachesHistory : UserControl
    {
        private DataBreachesController dBreachesController;
        private event HandleBackToMenu ChangeToMenu;
        private event HandleWindowChange ChangeWindow;
        private ShowDataBreachesHistory showDataBreaches;
        public DataBreachesHistory(DataBreachesController dBreachesController)
        {
            InitializeComponent();
            this.dBreachesController = dBreachesController;
            LoadDataBreaches();
        }

        public void AddListener(HandleBackToMenu del)
        {
            ChangeToMenu += del;
        }

        public void LoadDataBreaches()
        {
            this.dBreachList.DataSource = this.dBreachesController.ListDataBreaches();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            DisposeChildForms();
            ChangeToMenu();
        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            DataBreach dBreach = (DataBreach)dBreachList.SelectedItem;
            if(dBreach != null)
            {
                DisposeChildForms();
                this.showDataBreaches = new ShowDataBreachesHistory(dBreach);
                this.showDataBreaches.Show();
            }
        }

        private void DisposeChildForms()
        {
            if (this.showDataBreaches != null)
            {
                this.showDataBreaches.Dispose();
            }
        }

        }
}
