using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBl.Dal
{
    public class DataAcessHelper
    {
        public static IDataAccess CreatObject()
        {
            return new FileDataLayer();
        }
    }
}
