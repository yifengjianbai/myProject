using System;
using System.Collections.Generic;

namespace OpenAuth.Repository.dbContext
{
    public partial class Frmleavereq
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string RequestType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? EndTime { get; set; }
        public string RequestComment { get; set; }
        public string Attachment { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public string FlowInstanceId { get; set; }
    }
}
