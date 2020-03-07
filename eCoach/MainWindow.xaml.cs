using System.Collections.Generic;
using System.Linq;
using System.Windows;
using eCoach.ViewModels;
using eCoach.Windows;
using LogicLayer.Models;

namespace eCoach
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //DataContext = new CustomerViewModel();
            DataContext = ApplicationBuilder.GetCustomerViewModel();
        }

        
    }
}
