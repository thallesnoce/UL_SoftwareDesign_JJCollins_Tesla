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
    public class DestinationDataAccess
    {
        public List<DestinationEntity> ListDestinations()
        {
            var data = FlatFileHelper.ListAllDestinations();
            return data.Select(x => x).ToList();
        }

        public DestinationEntity GetDestination(int id)
        {
            var data = FlatFileHelper.ListAllDestinations();
            return data.Where(x => x.DestinationId == id).FirstOrDefault();
        }
    }
}