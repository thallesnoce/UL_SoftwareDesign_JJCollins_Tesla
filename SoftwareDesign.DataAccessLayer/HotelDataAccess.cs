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
    public class HotelDataAccess
    {
        FlatFileHelper context;
        public HotelDataAccess()
        {
            context = SingletonDBContext.GetContext();
        }

        public List<HotelEntity> ListHoteis()
        {
            var data = context.ListAllHoteis();
            return data.Select(x => x).ToList();
        }

        public HotelEntity GetHotel(int id)
        {
            var data = context.ListAllHoteis();
            return data.Where(x => x.HotelId == id).FirstOrDefault();
        }
    }
}