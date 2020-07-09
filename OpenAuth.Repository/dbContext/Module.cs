﻿using System;
using System.Collections.Generic;

namespace OpenAuth.Repository.dbContext
{
    public partial class Module
    {
        public string Id { get; set; }
        public string CascadeId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string HotKey { get; set; }
        public sbyte IsLeaf { get; set; }
        public sbyte IsAutoExpand { get; set; }
        public string IconName { get; set; }
        public int Status { get; set; }
        public string ParentName { get; set; }
        public string Vector { get; set; }
        public int SortNo { get; set; }
        public string ParentId { get; set; }
        public string Code { get; set; }
        public sbyte IsSys { get; set; }
    }
}