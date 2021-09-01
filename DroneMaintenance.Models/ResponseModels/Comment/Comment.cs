using System;

namespace DroneMaintenance.Models.ResponseModels.Comment
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Header { get; set;  }
        public string Text { get; set;  }
        public DateTime Date { get; set;  }
        public string UserName {  get; set; }
    }
}
