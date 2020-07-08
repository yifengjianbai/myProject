using System;
using System.Collections.Generic;

namespace OpenAuth.Repository.dbContext
{
    public partial class TableDiary
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? PublishTime { get; set; }
        public string Author { get; set; }
    }
}
