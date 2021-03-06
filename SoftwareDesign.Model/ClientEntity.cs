﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesign.Entities
{
    public class ClientEntity : UserEntity
    {
        public int ClientId { get; set; }
        public DateTime RegistedDate { get; set; }
        public int ZipCode { get; set; }
        public int ClientSince
        {
            get
            {
                var time = DateTime.Now - RegistedDate;
                return time.Days;
            }
        }
    }
}