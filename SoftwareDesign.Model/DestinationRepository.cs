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
    public class DestinationRepository
    {
        public List<Destination> ListDestinations()
        {
            var data = FlatFileHelper.ListAllDestinations();
            return data.Select(x => x).ToList();
        }

        public Destination GetDestination(int id)
        {
            var data = FlatFileHelper.ListAllDestinations();
            return data.Where(x => x.DestinationId == id).FirstOrDefault();
        }
    }
}