using SoftwareDesign.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SoftwareDesign.ControllerLayer.Business
{
    public class ConcreteObserver : Observer
    {
        public void updateState(int packageId)
        {
            var DataAccessLayer = new PackageDataAccess();
            DataAccessLayer.IncrementView(packageId);
           
           
        }




    }
}
