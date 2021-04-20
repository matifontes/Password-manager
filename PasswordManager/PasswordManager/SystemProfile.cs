﻿using System.Collections.Generic;

namespace PasswordManager
{
    public class SystemProfile
    {
        public string SystemPassword {get; set;}
        private List<Category> categories;
        private List<Password> passwords;
        private List<CreditCard> cards;

        public SystemProfile(string password) {
            this.SystemPassword = password;
            categories = new List<Category>();
            passwords = new List<Password>();
            cards = new List<CreditCard>();
        }

        public bool Login(string password) 
        {
            return password.Equals(SystemPassword);
        }

        public void AddCategory(Category category) 
        {
            this.categories.Add(category);
        }

        public bool CategoryExists(Category category) 
        {
            return this.categories.Contains(category);
        }

        public void AddPassword(Password pass)
        {
            this.passwords.Add(pass);
        }

        public bool PasswordExists(string pass)
        {
            foreach (Password passAux in passwords)
            {
                if (passAux.Pass.Equals(pass))
                {
                    return true;
                }
            }
            return false;
        }

        public void AddCreditCard(CreditCard card)
        {

        }

        public bool CreditCardExists(long cardNumber)
        {
            foreach (CreditCard cardAux in cards)
            {
                if (cardAux.Number.Equals(cardNumber))
                {
                    return true;
                }
            }
            return false;
        }
    }
}