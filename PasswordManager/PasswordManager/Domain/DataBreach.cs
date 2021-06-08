﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    public class DataBreach
    {
        public List<CreditCard> creditCards;
        public List<Password> passwords;
        public DateTime Date { get; set; }

        public DataBreach(List<CreditCard> creditCards, List<Password> passwords)
        {
            this.creditCards = creditCards;
            this.passwords = passwords;
            this.Date = DateTime.Now;
        }
    }
}
