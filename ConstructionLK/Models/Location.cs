namespace ConstructionLK.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Location
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Location()
        {
            ItemRequests = new HashSet<ItemRequest>();
        }
        public int Id { get; set; }
        //public Customer Customer { get; set; }
        //public int CustomerId { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        [StringLength(10)]
        public string Type { get; set; }

        //public int RequestId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemRequest> ItemRequests { get; set; }

        //public virtual ItemRequest ItemRequest { get; set; }
    }
}
