using System;
using System.IO;
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
    public partial class DataBreach : UserControl
    {
        private PasswordsController passwords;
        private CreditCardsController creditCards;
        private event HandleBackToMenu ChangeToMenu;
        private CreateModifyPassword passwordForm;
        private List<Password> passwordsLine;
        private List<CreditCard> creditCardsLine;
        public DataBreach(PasswordsController passwords, CreditCardsController creditCards)
        {
            InitializeComponent();
            this.creditCards = creditCards;
            this.passwords = passwords;
            LoadList();
        }

        public void AddListener(HandleBackToMenu del)
        {
            ChangeToMenu += del;
        }

        public void LoadList()
        {
            StreamReader readText = new StreamReader("C:\\dataBreach.txt");
            string line = "";
            line = readText.ReadLine();
            while (line != null)
            {
                listBox.Items.Add(line);




                line = readText.ReadLine();
            }
            readText.Close();
        }

        private void LoadPasswords(string password)
        {
            Password pass = new Password(password);
            passwordsLine.Add(pass);
        }

        private void LoadCreditCards(long creditCardNumber)
        {
            CreditCard creditCard = new CreditCard(creditCardNumber);
            creditCardsLine.Add(creditCard);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ChangeToMenu();
        }
    }
}
