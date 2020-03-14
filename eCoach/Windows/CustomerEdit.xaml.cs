using eCoach.Interfaces;
using eCoach.ViewModels;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace eCoach.Windows
{
    /// <summary>
    /// Interaktionslogik für CustomerEdit.xaml
    /// </summary>
    public partial class CustomerEdit : Window, ICloseable
    {
        public CustomerEdit(LogicLayer.Models.CustomerModel customer)
        {
            InitializeComponent();
            DataContext = ApplicationBuilder.GetCustomerEditViewModel(customer);
        }
    }
}
