using System;
using System.Collections.Generic;

namespace OpenAuth.Repository.dbContext
{
    public partial class Ticksanalysis
    {
        public int Code { get; set; }
        public DateTime Time { get; set; }
        public float WeiBi { get; set; }
        public float UpDown { get; set; }
    }
}
