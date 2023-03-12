using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBl.Dal
{
    public class FileDataLayer : IDataAccess
    {
        public void Create(string tableName)
        {
            try
            {
                File.Create(tableName);
            }
            catch { }
        }

        public void Delete(string tableName, string data)
        {
            try
            {
                File.WriteAllText(tableName, data);
            }
            catch { }
        }

        public string GetAll(string tableName)
        {
            try
            {
                return File.ReadAllText(tableName);
            }
            catch { return null; }
        }

        public void Insert(string tableName, string data)
        {
            try
            {
                File.AppendAllText(tableName, data);
            }
            catch { }
        }
    }
}
