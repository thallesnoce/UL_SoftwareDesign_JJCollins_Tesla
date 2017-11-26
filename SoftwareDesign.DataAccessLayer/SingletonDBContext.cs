using SoftwareDesign.DataAccessLayer.DataModel;
using SoftwareDesign.Entities;
using SoftwareDesign.Entities.Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SoftwareDesign.DataAccessLayer
{
    /// <summary>
    /// In the entity framework its easy to change from one database to another.
    /// If you do not have specific TSQL statement, you can just change the ConnectionString and make sure that the driver is installed.
    /// </summary>
    public static class SingletonDBContext
    {
        private static FlatFileHelper _context;

        public static FlatFileHelper GetContext()
        {
            if (_context == null)
            {
                _context = new FlatFileHelper();
            }

            return _context;
        }
    }
}