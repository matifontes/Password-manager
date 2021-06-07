using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.Repositories;

namespace PasswordManager.Controllers
{
    public class DataBreachesController
    {
        private DataBreachesRepository dBreaches;

        public DataBreachesController(DataBreachesRepository dBreaches)
        {
            this.dBreaches = dBreaches;
        }

        public void AddDataBreach(DataBreach dBreach)
        {
            this.dBreaches.AddDataBreach(dBreach);
        }

        public bool IsEmpty()
        {
            return this.dBreaches.IsEmpty();
        }

    }
}
