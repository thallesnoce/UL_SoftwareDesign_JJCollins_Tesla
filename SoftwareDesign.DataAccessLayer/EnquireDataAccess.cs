﻿using SoftwareDesign.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesign.DataAccessLayer
{
    /// <summary>
    /// Fake DataBase
    /// For all Where clauses, we are using LINQ.
    /// </summary>
    public class EnquireDataAccess
    {
        public EnquireEntity GetEnquire(EnquireEntity enquire)
        {
            throw new NotImplementedException();
        }

        public void RespondeEnquire(EnquireEntity enquire)
        {
            throw new NotImplementedException();
        }

        public void CreateEnquire(int packageId,String Message)
        {   
            // Data is  going to be saved in flatFile
            //var data = FlatFileHelper.ListAllPackages();
            //return data.Where(x => x.PackageId == packageId).FirstOrDefault();
           //
        }
    }
 }
    