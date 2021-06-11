using System.Collections.Generic;
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

        public void AddDataBreach(DataBreach dBreach)
        {
            this.dataBreaches.Add(dBreach);
        }

        public bool IsEmpty()
        {
           return this.dataBreaches.Count == 0;
        }

        public List<DataBreach> ListDataBreaches()
        {
            return this.dataBreaches.OrderBy(dBreach => dBreach.Date).ToList();
        }

        public bool PasswordExistOnDataBreaches(Password pass)
        {
            bool passwordExist = false;

            foreach (DataBreach dBreach in this.dataBreaches)
            {
                foreach (Password dBreachPassword in dBreach.passwords)
                {
                    if (dBreachPassword.Pass == pass.Pass)
                    {
                        return true;
                    }
                }
            }
            return passwordExist;
        }

    }
}
