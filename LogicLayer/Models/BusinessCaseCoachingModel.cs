using DBAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Models
{
    public class BusinessCaseCoachingModel : BusinessCaseModel
    {
        private const string tableName = "BusinessCaseCoaching";

        private string topic;
        public string Topic
        {
            get { return topic; }
            set
            {
                if(topic != value)
                {
                    topic = value;
                    OnPropertyChanged("Topic");
                }
            }
        }

        private string notes;
        public string Notes
        {
            get { return notes; }
            set 
            { 
                if(notes != value)
                {
                    notes = value;
                    OnPropertyChanged("Notes");
                }
            }
        }

        

        private DateTime startTime;
        public DateTime StartTime
        {
            get { return startTime; }
            set
            {
                if(startTime != value)
                {
                    startTime = value;
                    OnPropertyChanged("StartTime");
                }
            }
        }

        private DateTime endTime;
        public DateTime EndTime
        {
            get { return endTime; }
            set
            {
                if (endTime != value)
                {
                    endTime = value;
                    OnPropertyChanged("EndTime");
                }
            }
        }

        
        private int idRechnung;
        public int IdRechnung
        {
            get { return idRechnung; }
            set
            {
                if(idRechnung != value)
                {
                    idRechnung = value;
                    OnPropertyChanged("IdRechnung");
                }
            }
        }

        public BusinessCaseCoachingModel(DataRow dataRow)
            : base(dataRow)
        {
            UpdateFromRow(dataRow);
        }

        public BusinessCaseCoachingModel()
        {
        }

        private void UpdateFromRow(DataRow dataRow)
        {
            Topic = (string)dataRow["Topic"];
            Notes = (string)dataRow["Notes"];
            StartTime = (DateTime)dataRow["StartTime"];
            EndTime = (DateTime)dataRow["EndTime"];
            IdRechnung = (int)dataRow["IdRechnung"];
        }

        public void Save(IDbAccess dbAccess)
        {
            if(BusinessCaseId == 0)
            {
                //insert
                string sql = $"";// von baseclass string dieser properties holen
            }
            else
            {
                //update
            }
        }

        public static BusinessCaseCoachingModel[] Load(IDbAccess dbAccess)
        {
            DataTable dataTable = dbAccess.GetDataTable($"Select * FROM {tableName}");
            List<BusinessCaseCoachingModel> addressModels = new List<BusinessCaseCoachingModel>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                addressModels.Add(new BusinessCaseCoachingModel(dataRow));
            }
            return addressModels.ToArray();
        }
    }
}
