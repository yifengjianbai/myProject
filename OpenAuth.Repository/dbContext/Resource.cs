using System;
using System.Collections.Generic;

namespace OpenAuth.Repository.dbContext
{
    public partial class Resource
    {
        public string Id { get; set; }
        public string CascadeId { get; set; }
        public string Name { get; set; }
        public int SortNo { get; set; }
        public string Description { get; set; }
        public string ParentName { get; set; }
        public string ParentId { get; set; }
        public string AppId { get; set; }
        public string AppName { get; set; }
        public string TypeName { get; set; }
        public string TypeId { get; set; }
        public bool Disable { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string UpdateUserId { get; set; }
        public string UpdateUserName { get; set; }
    }
}
