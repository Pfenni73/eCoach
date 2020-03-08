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
        private int idAddress;
        private const string tableName = "Address";
        public int IdCustomer
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

        private int number;
        public int Number
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

        private int zipCode;
        public int ZipCode
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

        private int phoneHome;
        public int PhoneHome
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

        private int phoneMobile;
        public int PhoneMobile
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

        private int phoneOffice;
        private DataRow dataRow;

        public AddressModel(DataRow dataRow)
        {
            this.dataRow = dataRow;
        }

        public int PhoneOffice
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
    }
}
