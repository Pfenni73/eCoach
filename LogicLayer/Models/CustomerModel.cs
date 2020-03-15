using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using DBAccessLayer.Interfaces;
using DBAccessLayer;

namespace LogicLayer.Models
{
    public class CustomerModel : ModelBase
    {
        private int idCustomer;
        private const string tableName = "Customer";
        public int IdCustomer
        {
            get { return idCustomer; }
            set 
            {
                if(idCustomer != value)
                {
                    idCustomer = value;
                    OnPropertyChanged("IdCustomer");
                }
            }
        }

        internal static CustomerModel Load(IDbAccess dbAccess, int customerId)
        {
            throw new NotImplementedException();
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if(firstName != value)
                {
                    firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                if(lastName != value)
                {
                    lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

        

        private DateTime since;
        public DateTime Since
        {
            get { return since; }
            set 
            { 
                if(since != value)
                {
                    since = value;
                    OnPropertyChanged("Since");
                }
            }
        }

        private DateTime? birthdate;
        public DateTime? Birthdate
        {
            get { return birthdate; }
            set
            {
                if(birthdate != value)
                {
                    birthdate = value;
                    OnPropertyChanged("Birthdate");
                }
            }
        }

        public CustomerModel(DataRow dataRow)
        {
            UpdateFromRow(dataRow);
        }

        public CustomerModel()
        {
        }

        public CustomerModel(CustomerModel customer)
        {
            IdCustomer = customer.IdCustomer;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Since = customer.Since;
        }

        public CustomerModel GetShallowCopy()
        {
            return (CustomerModel)this.MemberwiseClone();
        }

        public void Reload(IDbAccess dbAccess)
        {
            DataTable dataTable = dbAccess.GetDataTable($"Select * FROM {tableName} WHERE IdCustomer = {IdCustomer}");
            if(dataTable.Rows.Count > 1)
            {
                throw new Exception($"Index {IdCustomer} auf Tabelle {tableName} ist nicht eindeutig");
            }
            UpdateFromRow(dataTable.Rows[0]);
        }

        public static CustomerModel[] Load(IDbAccess dbAccess)
        {
            DataTable dataTable = dbAccess.GetDataTable($"Select * FROM {tableName}");
            List<CustomerModel> customerModels = new List<CustomerModel>();
            foreach(DataRow dataRow in dataTable.Rows)
            {
                customerModels.Add(new CustomerModel(dataRow));
            }
            return customerModels.ToArray();
        }

        public int Save(IDbAccess dbAccess)
        {
            if(IdCustomer == 0)
            {
                string sqlString = $"insert {tableName} (FirstName, LastName, Since, Birthdate) values('{FirstName}', '{LastName}', GetDate(), {SqlHelper.GetSqlString(Birthdate)})";
                dbAccess.InsertDb(sqlString);
                DataTable dataTable = dbAccess.GetDataTable($"SELECT TOP 1 * FROM {tableName} ORDER BY IdCustomer DESC");
                this.UpdateFromRow(dataTable.Rows[0]);
            }
            else
            {
                string sqlString = $"UPDATE {tableName} SET FirstName = {SqlHelper.GetSqlString(FirstName)}, LastName = {SqlHelper.GetSqlString(LastName)}, Birthdate = {SqlHelper.GetSqlString(Birthdate)} WHERE idCustomer = {IdCustomer}";
                dbAccess.Update(sqlString);
            }
            return 0;
        }

        public void Delete(IDbAccess dbAccess)
        {
            string sql = $"DELETE FROM {tableName} WHERE IdCustomer = {IdCustomer}";
            dbAccess.Delete(sql);
        }

        private void UpdateFromRow(DataRow dataRow)
        {
            IdCustomer = (int)dataRow["IdCustomer"];
            FirstName = (string)dataRow["FirstName"];
            LastName = (string)dataRow["LastName"];
            Since = (DateTime)dataRow["Since"];
            Birthdate = dataRow.Field<DateTime?>("Birthdate");
        }
    }
}
