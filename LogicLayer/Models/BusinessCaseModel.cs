using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models
{
    /// <summary>
    /// Datamodel für einen Geschäftsfall (Allgemein).
    /// </summary>
    public class BusinessCaseModel : ModelBase
    {
        private int businessCaseId;
        public int BusinessCaseId
        {
            get { return businessCaseId; }
            set
            {
                if(businessCaseId != value)
                {
                    businessCaseId = value;
                    OnPropertyChanged("BusinessCaseId");
                }
            }
        }

        private DateTime date;
        /// <summary>
        /// Datum des Business Case
        /// </summary>
        public DateTime Date
        {
            get { return date; }
            set
            {
                if(date != value)
                {
                    date = value;
                    OnPropertyChanged("Date");
                }
            }
        }

        private int fkIdCustomer;
        public int IdCustomerFk
        {
            get { return fkIdCustomer; }
            set
            {
                if(fkIdCustomer != value)
                {
                    fkIdCustomer = value;
                    OnPropertyChanged("IdCustomerFk");
                }
            }
        }

        private float cost;
        public float Cost
        {
            get { return cost; }
            set
            {
                if(cost != value)
                {
                    cost = value;
                    OnPropertyChanged("Cost");
                }
            }
        }

        public BusinessCaseModel(DataRow dataRow)
        {
            BusinessCaseId = (int)dataRow["IdBusinessCase"];
            Date = (DateTime)dataRow["Date"];
            Cost = (float)dataRow["Costs"];
        }

        public BusinessCaseModel()
        {
            Date = DateTime.Now;
        }
    }
}
