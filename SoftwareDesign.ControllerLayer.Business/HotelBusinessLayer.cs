using SoftwareDesign.DataAccessLayer;
using SoftwareDesign.DataAccessLayer.DataModel;
using SoftwareDesign.Entities;
using System.Collections.Generic;

namespace SoftwareDesign.ControllerLayer.Business
{
    public class HotelBusinessLayer
    {
        public List<HotelEntity> ListHoteis()
        {
            return new HotelDataAccess().ListHoteis();
        }

        public HotelEntity GetHotel(int id)
        {
            return new HotelDataAccess().GetHotel(id);
        }
    }
}