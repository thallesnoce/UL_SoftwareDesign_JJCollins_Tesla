using SoftwareDesign.Model;
using SoftwareDesign.Model.DataModel;
using System;
using System.Collections.Generic;

namespace SoftwareDesign.ControllerLayer.Business
{
    public class TransportBusinessLayer
    {
        public List<Transport> ListTransports()
        {
            return new TransportRepository().ListTransports();            
        }

        public Transport GetTransport(int id)
        {
            return new TransportRepository().GetTransport(id);
        }
    }
}