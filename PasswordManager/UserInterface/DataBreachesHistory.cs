using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using PasswordManager;
using PasswordManager.Controllers;
using PasswordManagerDataLeyer.RepositoriesDB;

namespace UserInterface
{
    public partial class DataBreachesHistory : UserControl
    {
        private DataBreachRepository dBreaches;
        private ProfileController profile;
        private event HandleBackToMenu ChangeToMenu;
        private ShowDataBreachesHistory showDataBreaches;
        public DataBreachesHistory(ProfileController profile)
        {
            InitializeComponent();
            this.profile = profile;
            this.dBreaches = new DataBreachRepository(profile.GetProfile());
            LoadDataBreaches();
        }

        public void AddListener(HandleBackToMenu del)
        {
            ChangeToMenu += del;
        }

        public void LoadDataBreaches()
        {
            this.dBreachList.DataSource = this.dBreaches.GetAll();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            DisposeChildForms();
            ChangeToMenu();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            DataBreach dBreach = (DataBreach)dBreachList.SelectedItem;
            if(dBreach != null)
            {
                DisposeChildForms();
                this.showDataBreaches = new ShowDataBreachesHistory(this.profile, dBreach);
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
