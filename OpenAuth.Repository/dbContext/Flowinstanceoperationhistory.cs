using System;
using System.Collections.Generic;

namespace OpenAuth.Repository.dbContext
{
    public partial class Flowinstanceoperationhistory
    {
        public string Id { get; set; }
        public string InstanceId { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public string CreateUserName { get; set; }
    }
}
