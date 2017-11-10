namespace SoftwareDesign.Entities
{
    using System;
    using System.Collections.Generic;

    public class EnquireEntity
    {
        public int EnquirelId { get; set; }
        public string Comment { get; set; }
        public string Subject { get; set; }
        public Boolean IsUrgent { get; set; }
    }
}