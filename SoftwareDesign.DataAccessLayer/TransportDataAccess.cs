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
        public List<TransportEntity> ListTransports()
        {
            var data = FlatFileHelper.ListAllTransports();
            return data.Select(x => x).ToList();
        }

        public TransportEntity GetTransport(int id)
        {
            var data = FlatFileHelper.ListAllTransports();
            return data.Where(x => x.TransportId == id).FirstOrDefault();
        }
    }
}