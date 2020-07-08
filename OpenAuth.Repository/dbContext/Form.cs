using System;
using System.Collections.Generic;

namespace OpenAuth.Repository.dbContext
{
    public partial class Form
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int FrmType { get; set; }
        public string WebId { get; set; }
        public int Fields { get; set; }
        public string ContentData { get; set; }
        public string ContentParse { get; set; }
        public string Content { get; set; }
        public int SortCode { get; set; }
        public int DeleteMark { get; set; }
        public string DbName { get; set; }
        public int Disabled { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyUserId { get; set; }
        public string ModifyUserName { get; set; }
        public string OrgId { get; set; }
    }
}
