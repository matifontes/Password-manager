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
    public partial class DataBreachPanel : UserControl
    {
        private PasswordsController passwords;
        private CreditCardsController creditCards;
        private CategoriesController categories;
        private DataBreachesController dBreachesController;
        private event HandleBackToMenu ChangeToMenu;
        private event HandleWindowChange ChangeWindow;
        private List<Password> passwordsLine;
        private List<CreditCard> creditCardsLine;
        private string filePath;
        private string fileContent;
        public DataBreachPanel(PasswordsController passwords, CreditCardsController creditCards, CategoriesController categories, DataBreachesController dBreachesController)
        {
            InitializeComponent();
            this.creditCards = creditCards;
            this.passwords = passwords;
            this.categories = categories;
            this.passwordsLine = new List<Password>();
            this.creditCardsLine = new List<CreditCard>();
            this.filePath = String.Empty;
            this.fileContent = String.Empty;
            this.dBreachesController = dBreachesController;
        }

        public void AddListener(HandleBackToMenu del)
        {
            ChangeToMenu += del;
        }

        public void AddListener(HandleWindowChange del)
        {
            ChangeWindow += del;
        }

        private void LoadList()
        {
            this.passwordsLine.Clear();
            this.creditCardsLine.Clear();
            foreach(string line in txtBox.Lines)
            {
                if(line != string.Empty)
                {
                    LoadCreditCards(line);
                    LoadPasswords(line);
                }
            }
        }

        private void LoadPasswords(string password)
        {
            try
            {
                Password pass = new Password(password);
                this.passwordsLine.Add(pass);
            }
            catch
            {

            }

        }

        private void LoadCreditCards(string strCreditCardNumber)
        {
            try
            {
                string strNum = strCreditCardNumber.Replace(" ", String.Empty);
                long numberCreditCard = long.Parse(strNum);
                CreditCard creditCard = new CreditCard(numberCreditCard);
                this.creditCardsLine.Add(creditCard);
            }
            catch
            {

            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            ChangeToMenu();
        }

        private void BtnVerify_Click(object sender, EventArgs e)
        {
            LoadList();
            List<Password> passwordsList = this.passwords.ListPasswordsMatching(this.passwordsLine);
            List<CreditCard> creditCardlist = this.creditCards.GetMatchingCreditCards(this.creditCardsLine);

            dBreachesController.AddDataBreach(new DataBreach(creditCardlist, passwordsList));

            ListDataBreaches listDataBreaches = new ListDataBreaches(passwordsList, creditCardlist, this.categories, this.passwords, this.dBreachesController);
            listDataBreaches.AddListener(ReturnToDataBreach);
            ChangeWindow(listDataBreaches);
        }

        private void ReturnToDataBreach()
        {
            ChangeWindow(this);
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            this.FilePathReader();
            this.LoadListOfDataBreachesWithFile();
        }

        private void FilePathReader()
        {
            this.filePath = String.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();
                    StreamReader reader = new StreamReader(fileStream);
                    this.fileContent = reader.ReadToEnd();
                }
            }
        }

        private void LoadListOfDataBreachesWithFile()
        {
            String[] fileContentList = SeparateString();
           
            if(this.txtBox.Text != String.Empty)
            {
                this.txtBox.Text += "\r\n";
            }

            foreach (string str in fileContentList)
            {
                this.txtBox.Text += str + "\r\n";
            }
            this.fileContent = string.Empty;
        }

        private string[] SeparateString()
        {
            String[] separator = { "\\t" };
            String[] fileContentList = this.fileContent.Split(separator, StringSplitOptions.None);

            return fileContentList;
        }
    }
}
