using System;
using System.Collections.Generic;

namespace OpenAuth.Repository.dbContext
{
    public partial class Uploadfile
    {
        public string Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }
        public string FileType { get; set; }
        public int? FileSize { get; set; }
        public string Extension { get; set; }
        public sbyte Enable { get; set; }
        public int SortCode { get; set; }
        public sbyte DeleteMark { get; set; }
        public Guid? CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public DateTime CreateTime { get; set; }
        public string Thumbnail { get; set; }
        public string BelongApp { get; set; }
        public string BelongAppId { get; set; }
    }
}
