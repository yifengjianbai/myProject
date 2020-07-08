using System;
using System.Collections.Generic;

namespace OpenAuth.Repository.dbContext
{
    public partial class Sysmessage
    {
        public string Id { get; set; }
        public string TypeName { get; set; }
        public string TypeId { get; set; }
        public string FromId { get; set; }
        public string ToId { get; set; }
        public string FromName { get; set; }
        public string ToName { get; set; }
        public int FromStatus { get; set; }
        public int ToStatus { get; set; }
        public string Href { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreateId { get; set; }
    }
}
