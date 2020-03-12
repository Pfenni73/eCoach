using DBAccessLayer;
using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCoach.ViewModels
{
    public class CustomerDetailViewModel : ViewModelBase
    {
        private DbAccess dbAccess;
        private CustomerModel customer;
        public CustomerModel Customer 
        {
            get { return customer; }
            set
            {
                customer = value;
                OnPropertyChanged("Customer");
            }
        }
        public CustomerDetailViewModel(DbAccess dbAccess, CustomerModel customer)
        {
            this.dbAccess = dbAccess;
            this.Customer = customer;
        }
    }
}
