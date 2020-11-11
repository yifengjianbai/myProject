﻿using OpenAuth.Repository.dbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenAuth.App
{
    public class DatabaseHelper
    {
        private static yfjbContext yfjbContext;
        private DatabaseHelper() { }
        public static yfjbContext GetDbInstance(string constr)
        {
            if (yfjbContext == null)
            {
                yfjbContext = new yfjbContext(constr);
            }
            return yfjbContext;
        }
    }
}
