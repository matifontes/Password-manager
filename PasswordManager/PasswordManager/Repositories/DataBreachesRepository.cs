﻿using System.Collections.Generic;
using System.Linq;
using PasswordManager.Exceptions;

namespace PasswordManager.Repositories
{
    public class DataBreachesRepository
    {
        private List<DataBreach> dataBreaches;

        public DataBreachesRepository()
        {
            dataBreaches = new List<DataBreach>();
        }

        public bool IsEmpty()
        {
           return this.dataBreaches.Count == 0;
        }
    }
}
