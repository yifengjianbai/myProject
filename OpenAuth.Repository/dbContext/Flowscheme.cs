using System;
using System.Collections.Generic;

namespace OpenAuth.Repository.dbContext
{
    public partial class Flowscheme
    {
        public string Id { get; set; }
        public string SchemeCode { get; set; }
        public string SchemeName { get; set; }
        public string SchemeType { get; set; }
        public string SchemeVersion { get; set; }
        public string SchemeCanUser { get; set; }
        public string SchemeContent { get; set; }
        public string FrmId { get; set; }
        public int FrmType { get; set; }
        public int AuthorizeType { get; set; }
        public int SortCode { get; set; }
        public int DeleteMark { get; set; }
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
