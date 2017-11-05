using SoftwareDesign.DataAccessLayer;
using SoftwareDesign.DataAccessLayer.DataModel;
using SoftwareDesign.Entities;
using System.Collections.Generic;

namespace SoftwareDesign.ControllerLayer.Business
{
    public class TransportBusinessLayer
    {
        public List<TransportEntity> ListTransports()
        {
            return new TransportDataAccess().ListTransports();
        }

        public TransportEntity GetTransport(int id)
        {
            return new TransportDataAccess().GetTransport(id);
        }
    }
}