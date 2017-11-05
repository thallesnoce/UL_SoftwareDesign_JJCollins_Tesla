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
        public List<HotelEntity> ListHoteis()
        {
            var data = FlatFileHelper.ListAllHoteis();
            return data.Select(x => x).ToList();
        }

        public HotelEntity GetHotel(int id)
        {
            var data = FlatFileHelper.ListAllHoteis();
            return data.Where(x => x.HotelId == id).FirstOrDefault();
        }
    }
}