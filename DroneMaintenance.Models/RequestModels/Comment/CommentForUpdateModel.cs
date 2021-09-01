using System;
using System.Collections.Generic;
using System.Text;

namespace DroneMaintenance.Models.RequestModels.Comment
{
    public class CommentForUpdateModel
    {
        public string Header { get; set; }
        public string Text { get; set; }
        public Guid UserId { get; set; }
    }
}
