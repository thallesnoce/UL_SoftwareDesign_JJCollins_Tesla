using SoftwareDesign.Model.DataModel;
using SoftwareDesign.Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareDesign.Model
{
    /// <summary>
    /// All data are mockup from flatfile using the "FlatFileHelper"
    /// </summary>
    public class HotelRepository
    {
        public List<Hotel> ListHoteis()
        {
            var data = FlatFileHelper.ListAllHoteis();
            return data.Select(x => x).ToList();
        }

        public Hotel GetHotel(int id)
        {
            var data = FlatFileHelper.ListAllHoteis();
            return data.Where(x => x.HotelId == id).FirstOrDefault();
        }
    }
}