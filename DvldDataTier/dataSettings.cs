using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvldDataTier
{
    internal class dataSettings
    {
        static public string ConnectionString = $@"server={secureInfo.server};database={secureInfo.database};
        user ID={secureInfo.username};password={secureInfo.password}";
    }
}
