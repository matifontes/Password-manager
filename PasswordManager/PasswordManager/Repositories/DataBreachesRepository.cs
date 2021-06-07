using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Repositories
{
    public class DataBreachesRepository
    {
        private List<DataBreach> dataBreaches;

        public DataBreachesRepository()
        {
            this.dataBreaches = new List<DataBreach>();
        }
    }
}
