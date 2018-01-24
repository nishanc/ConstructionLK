namespace ConstructionLK.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PublishedItem
    {
        //[Key]
        //[Column(Order = 0)]
        //public int Id { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemId { get; set; }

        public float Price { get; set; }

        public float? Discount { get; set; }

        public virtual Item Item { get; set; }

        public virtual ServiceProvider ServiceProvider { get; set; }
    }
}
