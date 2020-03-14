using DBAccessLayer.Interfaces;
using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.BusinessModels
{
    public class CustomerBusinessModel
    {
        private IDbAccess dbAccess;
        
        private int customerId;

        public CustomerBusinessModel(IDbAccess dbAccess,  int customerId)
        {
            this.dbAccess = dbAccess;
            this.customerId = customerId;

            Data = CustomerModel.Load(dbAccess, customerId);
        }

        public CustomerBusinessModel(CustomerModel customerModel)
        {
            Data = customerModel;
        }

        public CustomerBusinessModel(IDbAccess dbAccess, CustomerModel customerModel)
        {
            this.dbAccess = dbAccess;
            Data = customerModel;
        }

        public CustomerModel Data { get; set; }

        /// <summary>
        /// Gibt die Adresse des Kunden zurück.
        /// Wie handhaben, wenn es mehrere Adressen gibt?
        /// </summary>
        /// <param name="dbAccess"></param>
        /// <returns></returns>
        public AddressModel GetAddressModel(IDbAccess dbAccess)
        {
            AddressModel[] addressModels = AddressModel.Load(dbAccess, Data.IdCustomer);
            if(addressModels.Length > 0)
            {
                return addressModels[0];
            }
            return null;
        }

        public static CustomerBusinessModel Load(IDbAccess dbAccess, int customerId)
        {

            return new CustomerBusinessModel(dbAccess, customerId);
        }

        public static CustomerBusinessModel Load(IDbAccess dbAccess, CustomerModel customerModel)
        {

            return new CustomerBusinessModel(dbAccess, customerModel);
        }
    }
}
