using DBAccessLayer;
using DBAccessLayer.Interfaces;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models
{
    public class AddressModel : ModelBase
    {
        private const string tableName = "Address";
        #region Konstruktoren
        public AddressModel(DataRow dataRow)
        {
            //this.dataRow = dataRow;
            UpdateFromRow(dataRow);
        }

        public AddressModel()
        {
        }
        #endregion

        #region Field Properties        
        private int idAddress;
        public int IdAddress
        {
            get { return idAddress; }
            set
            {
                if (idAddress != value)
                {
                    idAddress = value;
                    OnPropertyChanged("IdAddress");
                }
            }
        }

        private int fkCustomer;
        public int FkCustomer
        {
            get { return fkCustomer; }
            set
            {
                if(fkCustomer != value)
                {
                    fkCustomer = value;
                    OnPropertyChanged("FkCustomer");
                }
            }
        }

        private string street;
        public string Street
        {
            get { return street; }
            set
            {
                if(street != value)
                {
                    street = value;
                    OnPropertyChanged("Street");
                }
            }
        }

        private int? number;
        public int? Number
        {
            get { return number; }
            set
            {
                if(number!= value)
                {
                    number = value;
                    OnPropertyChanged("Number");
                }
            }
        }

        private int? zipCode;
        public int? ZipCode
        {
            get { return zipCode; }
            set
            {
                if(zipCode != value)
                {
                    zipCode = value;
                    OnPropertyChanged("ZipCode");
                }
            }
        }

        private string city;
        public string City
        {
            get { return city; }
            set
            {
                if(city != value)
                {
                    city = value;
                    OnPropertyChanged("City");
                }
            }
        }

        private int? phoneHome;
        public int? PhoneHome
        {
            get { return phoneHome; }
            set
            {
                if(phoneHome != value)
                {
                    phoneHome = value;
                    OnPropertyChanged("PhoneHome");
                }
            }
        }

        private int? phoneMobile;
        public int? PhoneMobile
        {
            get { return phoneMobile; }
            set
            {
                if(phoneMobile != value)
                {
                    phoneMobile = value;
                    OnPropertyChanged("PhoneMobile");
                }
            }
        }

        private int? phoneOffice;
        public int? PhoneOffice
        {
            get { return phoneOffice; }
            set
            {
                if (phoneOffice != value)
                {
                    phoneOffice = value;
                    OnPropertyChanged("PhoneOffice");
                }
            }
        }
 #endregion

        public static AddressModel[] Load(IDbAccess dbAccess)
        {
            DataTable dataTable = dbAccess.GetDataTable($"Select * FROM {tableName}");
            List<AddressModel> addressModels = new List<AddressModel>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                addressModels.Add(new AddressModel(dataRow));
            }
            return addressModels.ToArray();
        }

        public static AddressModel[] Load(IDbAccess dbAccess, int idCustomer)
        {
            DataTable dataTable = dbAccess.GetDataTable($"Select * FROM {tableName} WHERE fk_IdCustomer = {idCustomer}");
            List<AddressModel> addressModels = new List<AddressModel>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                addressModels.Add(new AddressModel(dataRow));
            }
            return addressModels.ToArray();
        }

        public void Save(IDbAccess dbAccess, int idCustomer)
        {
            if (idAddress == 0)
            {
                string sqlString = $"insert {tableName} (fk_idCustomer, Street, Number, ZipCode, City, PhoneHome, PhoneMobile, PhoneOffice) values({idCustomer}, '{Street}', {SqlHelper.GetSqlString(Number)}, {SqlHelper.GetSqlString(ZipCode)}, '{City}', {SqlHelper.GetSqlString(PhoneHome)}, {SqlHelper.GetSqlString(PhoneMobile)}, {SqlHelper.GetSqlString(PhoneOffice)})";
                dbAccess.InsertDb(sqlString);
                DataTable dataTable = dbAccess.GetDataTable($"SELECT TOP 1 * FROM {tableName} ORDER BY IdAddress DESC");
                this.UpdateFromRow(dataTable.Rows[0]);
            }
            else
            {
                string sqlString = $"UPDATE {tableName} SET Street = '{Street}', Number = {SqlHelper.GetSqlString(Number)}, ZipCode = {SqlHelper.GetSqlString(ZipCode)}, City = '{City}', PhoneHome = {SqlHelper.GetSqlString(PhoneHome)}, PhoneMobile = {SqlHelper.GetSqlString(PhoneMobile)}, PhoneOffice = {SqlHelper.GetSqlString(PhoneOffice)} WHERE idAddress = {IdAddress}";
                dbAccess.Update(sqlString);
            }
        }

        private void UpdateFromRow(DataRow dataRow)
        {
            IdAddress = (int)dataRow["IdAddress"];
            FkCustomer = (int)dataRow["fk_idCustomer"];
            Street = (string)dataRow["Street"];
            Number = SqlHelper.GetValue(dataRow, "Number");//(int?)((dataRow["Number"] != DBNull.Value) ? dataRow["Number"] : null);
            ZipCode = SqlHelper.GetValue(dataRow, "ZipCode");//(int?)dataRow["ZipCode"];
            City = (String)dataRow["City"];
            PhoneHome = SqlHelper.GetValue(dataRow, "PhoneHome");
            PhoneMobile = SqlHelper.GetValue(dataRow, "PhoneMobile");
            PhoneOffice = SqlHelper.GetValue(dataRow, "PhoneOffice");
        }
    }
}
