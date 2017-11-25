namespace ConstructionLK.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RatingsCustomer")]
    public partial class RatingsCustomer
    {
        public int Id { get; set; }

        public int PostUser { get; set; }

        public int ReceivedUser { get; set; }

        public byte Rate { get; set; }

        public int RequestId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ItemRequest ItemRequest { get; set; }

        public virtual ServiceProvider ServiceProvider { get; set; }
    }
}
