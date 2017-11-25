namespace ConstructionLK.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ItemPayment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public DateTime DateAndTime { get; set; }

        public float Amount { get; set; }

        public int RequestId { get; set; }

        public virtual ItemRequest ItemRequest { get; set; }
    }
}
