using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConstructionLK.Models
{
    public class ItemLocations
    {
        public int Id { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public virtual Item Item { get; set; }

        public int ItemId { get; set; }
    }
}