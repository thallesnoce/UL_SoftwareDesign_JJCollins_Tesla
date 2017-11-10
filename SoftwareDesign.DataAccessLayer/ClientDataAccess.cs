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
    /// All data are mockup from flatfile using the "FlatFileHelper"
    /// </summary>
    public class ClientDataAccess
    {
        public void Update(ClientEntity client)
        {
            throw new NotImplementedException();
        }

        public void Create(ClientEntity client)
        {
            throw new NotImplementedException();
        }

        public ClientEntity GetClient(int clientId)
        {
            return new ClientEntity() { UserId = 1, UserName = "First User" };
        }
    }
}