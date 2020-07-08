﻿using System;
using System.Collections.Generic;

namespace OpenAuth.Repository.dbContext
{
    public partial class Moduleelement
    {
        public string Id { get; set; }
        public string DomId { get; set; }
        public string Name { get; set; }
        public string Attr { get; set; }
        public string Script { get; set; }
        public string Icon { get; set; }
        public string Class { get; set; }
        public string Remark { get; set; }
        public int Sort { get; set; }
        public string ModuleId { get; set; }
        public string TypeName { get; set; }
        public string TypeId { get; set; }
    }
}
