using SoftwareDesign.DataAccessLayer;
using SoftwareDesign.DataAccessLayer.DataModel;
using SoftwareDesign.Entities;
using System;
using System.Collections.Generic;

namespace SoftwareDesign.ControllerLayer.Business
{
    public class DestinationBusinessLayer
    {
        public List<DestinationEntity> ListDestinations()
        {
            return new DestinationDataAccess().ListDestinations();
        }

        public DestinationEntity GetDestination(int id)
        {
            return new DestinationDataAccess().GetDestination(id);
        }
    }
}