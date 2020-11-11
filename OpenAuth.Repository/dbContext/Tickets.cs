using System;
using System.Collections.Generic;

namespace OpenAuth.Repository.dbContext
{
    public partial class Tickets
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
