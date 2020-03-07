using DBAccessLayer.Interfaces;
using eCoach.Windows;
using LogicLayer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace eCoach.ViewModels
{
    public class CustomerViewModel : ViewModelBase
    {
        private ICommand saveCommand;
        private BaseCommand deleteCommand;
        private BaseCommand editCommand;
        private IDbAccess dbAccess;
        public CustomerViewModel(IDbAccess dbAccess)
        {
            this.dbAccess = dbAccess;
            Customers = CustomerModel.Load(dbAccess);
        }

        private void EditCustomer(object p)
        {
            CustomerModel customer = (CustomerModel)p;
            CustomerEdit customerEdit = new CustomerEdit(customer.GetShallowCopy());
            if ((customerEdit.ShowDialog() ?? true) && customerEdit.DialogResult.Value == true)
            {
                CustomerModel changedCustomer = ((CustomerEditViewModel)customerEdit.DataContext).Customer;
                var cust = Customers.Where(c => c.IdCustomer == customer.IdCustomer);
                foreach(CustomerModel customerModel in cust)
                {
                    customerModel.Reload(dbAccess);
                }
            }
        }

        private void DeleteCustomer(object p)
        {
            CustomerModel customer = (CustomerModel)p;
            List<CustomerModel> customerModels = Customers.ToList();
            customerModels.Remove(customer);
            Customers = customerModels.ToArray();
            customer.Delete(dbAccess);
        }

        private CustomerModel[] customerModels;
        public CustomerModel[] Customers
        {
            get { return customerModels; }
            set
            {
                customerModels = value;
                OnPropertyChanged("Customers");
            }
        }

        public ICommand CustomerSaveCommand
        {
            get
            {
                return saveCommand ?? (saveCommand = new CommandHandler(() => ActionSave(), () => { return true; }));
            }
        }

        public BaseCommand DeleteCommand 
        { 
            get 
            { 
                if(deleteCommand == null)
                {
                    deleteCommand = new BaseCommand((p) => true, (p) => DeleteCustomer(p));
                }
                return deleteCommand; 
            }
            set { deleteCommand = value; } 
        }

        public BaseCommand EditCommand
        {
            get 
            {
                if (editCommand == null)
                {
                    editCommand = new BaseCommand((p) => true, (p) => EditCustomer(p));
                }
                return editCommand; 
            }
            set { editCommand = value; }
        }

        public void ActionSave()
        {
            CustomerModel customer = new CustomerModel();
            new CustomerEdit(customer).ShowDialog();
            if(customer.IdCustomer != 0)
            {
                Customers = Customers.Append(customer).ToArray();
            }
            
        }
    }
}
