namespace ConstructionLK.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Contact
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        public int ContactTypeId { get; set; }

        [Required]
        [StringLength(10)]
        public string Title { get; set; }

        [Required]
        public string Value { get; set; }

        public virtual ContactType ContactType { get; set; }

        public virtual ServiceProvider ServiceProvider { get; set; }
    }
}
