using SoftwareDesign.Model;
using SoftwareDesign.Model.DataModel;
using System;
using System.Collections.Generic;

namespace SoftwareDesign.ControllerLayer.Business
{
    public class HotelBusinessLayer
    {
        public List<Hotel> ListHoteis()
        {
            return new HotelRepository().ListHoteis();
        }

        public Hotel GetHotel(int id)
        {
            return new HotelRepository().GetHotel(id);
        }
    }
}