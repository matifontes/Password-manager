using System.Collections.Generic;
using System.Linq;

namespace PasswordManager
{
    public class PasswordRepository
    {

        private List<Password> passwords;
        public PasswordRepository() 
        {
            passwords = new List<Password>();        
        }

        public void AddPassword(Password password) 
        {
            this.passwords.Add(password);
        }

        public void RemovePassword(Password password) 
        {
            this.passwords.Remove(password);
        }

        public bool IsEmpty() 
        {
            return this.Count() == 0;
        }

        public bool IsEmptyList(List<Password> listPass)
        {
            return listPass.Count == 0;
        }

        public int Count() {
            return this.passwords.Count;
        }

        public List<Password> ListPasswords() 
        {
            return this.passwords.OrderBy(password => password.Category.Name).ToList();
        }

        public List<Password> ListRedPasswords()
        {
            List<Password> redPasswords = new List<Password>();
            foreach (Password pass in this.passwords)
            {
                if (pass.Strength == "Red")
                {
                    redPasswords.Add(pass);
                }
            }
            return SortListByCategoryName(redPasswords);
        }

        public List<Password> ListOrangePasswords()
        {
            List<Password> orangePasswords = new List<Password>();
            foreach (Password pass in this.passwords)
            {
                if (pass.Strength == "Orange")
                {
                    orangePasswords.Add(pass);
                }
            }
            return SortListByCategoryName(orangePasswords);
        }

        public List<Password> ListYellowPasswords()
        {
            List<Password> yellowPasswords = new List<Password>();
            foreach (Password pass in this.passwords)
            {
                if (pass.Strength == "Yellow")
                {
                    yellowPasswords.Add(pass);
                }
            }
            return SortListByCategoryName(yellowPasswords);
        }

        public List<Password> ListLGreenPasswords()
        {
            List<Password> lGreenPasswords = new List<Password>();
            foreach (Password pass in this.passwords)
            {
                if (pass.Strength == "LightGreen")
                {
                    lGreenPasswords.Add(pass);
                }
            }
            return SortListByCategoryName(lGreenPasswords);
        }

        public List<Password> ListDGreenPasswords()
        {
            List<Password> dGreenPasswords = new List<Password>();
            foreach (Password pass in this.passwords)
            {
                if (pass.Strength == "DarkGreen")
                {
                    dGreenPasswords.Add(pass);
                }
            }
            return SortListByCategoryName(dGreenPasswords);
        }

        public List<Password> SortListByCategoryName(List<Password> pass)
        {
            return pass.OrderBy(password => password.Category.Name).ToList();
        }

        public List<Password> GetPasswordMatching(List<Password> passList)
        {
            List<Password> ret = new List<Password>();
            foreach (Password pass in this.passwords)
            {
                foreach (Password pass2 in passList)
                {
                    if (pass.Pass.Equals(pass2.Pass) && !ret.Contains(pass))
                    {
                        ret.Add(pass);
                    }
                }
            }
            return ret;
        }

        public bool PasswordExist(List<Password> passList, string pass)
        {
            bool exist = false;
            foreach (Password password in passList)
            {
                if(password.Pass == pass)
                {
                    exist = true;
                }
            }
            return exist;
        }

    }
}