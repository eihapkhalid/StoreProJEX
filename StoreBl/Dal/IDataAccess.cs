using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBl.Dal
{
    public interface IDataAccess
    {
        void Create(string tableName);
        void Insert(string tableName, string data);
        void Delete(string tableName, string data);
        string GetAll(string tableName);
    }
}
