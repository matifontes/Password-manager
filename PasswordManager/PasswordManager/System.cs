﻿using System.Collections.Generic;

namespace PasswordManager
{
    public class System
    {
        public string SystemPassword {get; set;}
        private List<Categorie> categories;

        public System(string password) {
            this.SystemPassword = password;
            categories = new List<Categorie>();
        }

        public bool Login(string password) 
        {
            return password.Equals(SystemPassword);
        }

        public void AddCategory(Categorie category) 
        {

        }

        public bool CategoryExists(Categorie category) 
        {
            return true;
        }
    }
}