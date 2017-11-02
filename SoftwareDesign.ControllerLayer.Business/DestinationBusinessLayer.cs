using SoftwareDesign.Model;
using SoftwareDesign.Model.DataModel;
using System;
using System.Collections.Generic;

namespace SoftwareDesign.ControllerLayer.Business
{
    public class DestinationBusinessLayer
    {
        public List<Destination> ListDestinations()
        {
            return new DestinationRepository().ListDestinations();
        }

        public Destination GetDestination(int id)
        {
            return new DestinationRepository().GetDestination(id);
        }
    }
}