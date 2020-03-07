using eCoach.Interfaces;
using eCoach.ViewModels;
using System.Windows;

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
            //((CustomerEditViewModel)DataContext).Customer = customer;
        }
    }
}
