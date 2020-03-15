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

        public static string GetSqlString(string text)
        {
            return $"'{text}'";
        }

        public static string GetSqlString(DateTime dateTime)
        {
            return $"Convert(date,'{dateTime.Date}',103)";
        }

        public static string GetSqlString(DateTime? dateTime)
        {
            if(dateTime == null)
            {
                return "null";
            }
            DateTime tmpDate = dateTime ?? DateTime.MinValue;
            return $"Convert(date,'{tmpDate.Date}',103)";
        }

        public static int? GetValue(DataRow dataRow, string fieldName)
        {
            return (int?)((dataRow[fieldName] != DBNull.Value) ? dataRow[fieldName] : null);
        }
    }
}
