using SoftwareDesign.Model.DataModel;
using SoftwareDesign.Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareDesign.Model
{
    /// <summary>
    /// All data are mockup from flatfile using the "FlatFileHelper"
    /// </summary>
    public class TransportRepository
    {
        public List<Transport> ListTransports()
        {
            var data = FlatFileHelper.ListAllTransports();
            return data.Select(x => x).ToList();
        }

        public Transport GetTransport(int id)
        {
            var data = FlatFileHelper.ListAllTransports();
            return data.Where(x => x.TransportId == id).FirstOrDefault();
        }
    }
}