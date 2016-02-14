using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exact.Criccard.Domain.Entities
{
    public abstract class CriccardModelInitializer
    {
        public static void Initialize()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CriccardModel>());
        }
    }
}
