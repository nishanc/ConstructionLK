using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConstructionLK.Models
{
    public class CustomerCurrentLocation
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}