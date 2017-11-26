using SoftwareDesign.DataAccessLayer.DataModel;
using SoftwareDesign.Entities;
using SoftwareDesign.Entities.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareDesign.DataAccessLayer
{
    /// <summary>
    /// All data are mockup from flatfile using the "FlatFileHelper"
    /// </summary>
    public class TransportDataAccess
    {
        FlatFileHelper context;
        public TransportDataAccess()
        {
            context = SingletonDBContext.GetContext();
        }

        public List<TransportEntity> ListTransports()
        {
            var data = context.ListAllTransports();
            return data.Select(x => x).ToList();
        }

        public TransportEntity GetTransport(int id)
        {
            var data = context.ListAllTransports();
            return data.Where(x => x.TransportId == id).FirstOrDefault();
        }
    }
}