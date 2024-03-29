﻿using System;
using System.Collections.Generic;

namespace OpenAuth.Repository.dbContext
{
    public partial class Application
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string AppSecret { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public sbyte Disable { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreateUser { get; set; }
    }
}
