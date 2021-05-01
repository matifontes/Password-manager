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
    public delegate void HandleCreation();
    public partial class RegisterProfile : UserControl
    {
        private SystemProfile profile;
        private event HandleCreation PostRegisterEvent;

        public RegisterProfile()
        {
            InitializeComponent();
        }

        public void AddListener(HandleCreation del) {
            PostRegisterEvent += del;
        }

        private void RegisterProfile_Load(object sender, EventArgs e)
        {

        }

        private void btnCreateProfile_Click(object sender, EventArgs e)
        {

        }

    }
}
