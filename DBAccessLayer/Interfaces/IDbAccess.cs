using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccessLayer.Interfaces
{
    public interface IDbAccess
    {
        DataTable GetDataTable(string sqlString);
        void InsertDb(string sqlString);

        void Delete(string sqlString);
        void Update(string sqlString);
    }
}
