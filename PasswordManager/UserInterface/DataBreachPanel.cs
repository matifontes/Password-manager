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
using PasswordManagerDataLeyer.RepositoriesDB;

namespace UserInterface
{
    public partial class DataBreachPanel : UserControl
    {
        private CreditCardRepository creditCards;
        private ProfileController profile;
        private PasswordRepository passwords;
		private DataBreachRepository dBreaches;
        private event HandleBackToMenu ChangeToMenu;
        private event HandleWindowChange ChangeWindow;
        private List<Password> passwordsLine;
        private List<CreditCard> creditCardsLine;
        private string filePath;
        private string fileContent;

        public DataBreachPanel(ProfileController profile)
        {
            InitializeComponent();
            this.profile = profile;
            this.passwords = new PasswordRepository(profile.GetProfile());
            this.creditCards = new CreditCardRepository(profile.GetProfile());
            this.dBreaches = new DataBreachRepository(profile.GetProfile());
            this.passwordsLine = new List<Password>();
            this.creditCardsLine = new List<CreditCard>();
            this.filePath = String.Empty;
            this.fileContent = String.Empty;
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
            List<Password> passwordsList = (List<Password>)this.passwords.GetAllWithSamePassword(this.passwordsLine);
            List<CreditCard> creditCardlist = (List<CreditCard>)this.creditCards.GetAllWithSameNumber(this.creditCardsLine);
            DataBreach dataBreach = new DataBreach(creditCardlist, passwordsList);
            dBreaches.Add(dataBreach);
            ListDataBreaches listDataBreaches = new ListDataBreaches(dataBreach, this.passwords, this.profile, this.dBreaches);
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
