using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccessLayer
{
    public class SqlHelper
    {
        public static string GetSqlString(int? number)
        {
            if(number == null)
            {
                return "null";
            }
            return number.ToString();
        }

        public static int? GetValue(DataRow dataRow, string fieldName)
        {
            return (int?)((dataRow[fieldName] != DBNull.Value) ? dataRow[fieldName] : null);
        }
    }
}
