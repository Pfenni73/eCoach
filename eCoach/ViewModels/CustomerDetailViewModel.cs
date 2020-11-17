﻿using DBAccessLayer;
using LogicLayer.BusinessModels;
using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCoach.ViewModels
{
    public class CustomerDetailViewModel : ViewModelBase
    {
        private DbAccess dbAccess;
        private CustomerModel customer;
        private AddressModel address;
        private ObservableCollection<BusinessCaseCoachingModel> coachings;
        public CustomerModel Customer 
        {
            get { return customer; }
            set
            {
                customer = value;
                OnPropertyChanged("Customer");
            }
        }

        public AddressModel Address
        {
            get { return address; }
            set 
            { 
                address = value;
                OnPropertyChanged("Address");
            }
        }

        public ObservableCollection<BusinessCaseCoachingModel> Coachings
        {
            get { return coachings; }
            set
            {
                coachings = value;
                OnPropertyChanged("Coachings");
            }
        }
        public CustomerDetailViewModel(DbAccess dbAccess, CustomerModel customer)
        {
            this.dbAccess = dbAccess;
            this.Customer = customer;
            CustomerBusinessModel customerBusinessModel = CustomerBusinessModel.Load(dbAccess, customer);
            Address = customerBusinessModel.GetAddressModel(dbAccess);
            Coachings = BusinessCaseCoachingModel.Load(dbAccess).ToList<BusinessCaseCoachingModel>();
        }
    }
}
