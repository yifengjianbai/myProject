using System;
using System.Collections.Generic;

namespace OpenAuth.Repository.dbContext
{
    public partial class Music
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Tag { get; set; }
        public string Pic { get; set; }
        public string Album { get; set; }
        public string Singer { get; set; }
        public string Url { get; set; }
        public DateTime PubTime { get; set; }
        public int Status { get; set; }
    }
}
