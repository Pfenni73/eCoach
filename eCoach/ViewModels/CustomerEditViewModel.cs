using DBAccessLayer.Interfaces;
using eCoach.Interfaces;
using LogicLayer.Models;
using System.Windows;

namespace eCoach.ViewModels
{
    public class CustomerEditViewModel : ViewModelBase
    {
        private BaseCommand _saveCommand;
        private BaseCommand _quitCommand;
        public BaseCommand SaveCommand
        {
            get { return _saveCommand; }
            set { _saveCommand = value; }
        }

        public BaseCommand QuitCommand
        {
            get { return _quitCommand; }
            set { _quitCommand = value; }
        }

        private CustomerModel customer;
        private IDbAccess dbAccess;

        public CustomerModel Customer
        {
            get { return customer; }
            set
            {
                customer = value;
                OnPropertyChanged("Customer");
            }
        }

        public CustomerEditViewModel(DBAccessLayer.DbAccess dbAccess, CustomerModel customer)
        {
            this.dbAccess = dbAccess;
            Customer = customer;
            SaveCommand = new BaseCommand((p) => true, (p) => ActionSave(p));
            QuitCommand = new BaseCommand((p) => true, (p) => ActionQuit(p));
        }

        /// <summary>
        /// Methode für den Abbrechen Command
        /// Fragt den User ob er wirklich abbrechen will. Falls ja, wird das User-Property wieder auf den Originalzustand gesetzt.
        /// </summary>
        /// <param name="p">IClosable Instanz (Window)</param>
        private void ActionQuit(object p)
        {
            if(MessageBox.Show("Wollen Sie abbrechen?", "Abbrechen", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ((Window)p).DialogResult = false;
                CloseWindow((ICloseable)p);
            }
        }

        //public ICommand CustomerSaveCommand
        //{
        //    get
        //    {
        //        return saveCommand ?? (saveCommand = new CommandHandler(() => ActionSave(), () => { return true; }));
        //        //return saveCommand ?? (saveCommand = new CommandHandler((p) => ActionSave(), (p) => true;));
        //    }
        //}

        //public void ActionSave()
        //{
        //    Customer.Save(dbAccess);
        //}

        public void ActionSave(object o)
        {
            Customer.Save(dbAccess);
            ((Window)o).DialogResult = true;
            CloseWindow((ICloseable)o);
        }

        public void CloseWindow(ICloseable window)
        {
            if (window != null)
            {
                window.Close();
            }
        }
    }
}
