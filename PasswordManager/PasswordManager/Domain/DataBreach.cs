﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    public class DataBreach
    {
        private List<CreditCard> creditCards;
        private List<Password> passwords;

        public DataBreach(List<CreditCard> creditCards, List<Password> passwords)
        {
            this.creditCards = new List<CreditCard>();
            this.passwords = new List<Password>();
        }
    }
}
