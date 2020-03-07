using eCoach.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCoach
{
    public class ApplicationBuilder
    {
        public static CustomerViewModel GetCustomerViewModel()
        {
            return new CustomerViewModel(new DBAccessLayer.DbAccess());
        }

        internal static object GetCustomerEditViewModel(LogicLayer.Models.CustomerModel customer)
        {
            CustomerEditViewModel customerEditViewModel = new CustomerEditViewModel(new DBAccessLayer.DbAccess(), customer);
            //customerEditViewModel.Customer = customer;
            return customerEditViewModel;
        }
    }
}
