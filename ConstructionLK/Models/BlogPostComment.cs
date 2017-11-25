namespace ConstructionLK.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BlogPostComment
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PostId { get; set; }

        [Required]
        public string ContentOfComment { get; set; }

        public int UserId { get; set; }

        public virtual BlogPost BlogPost { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
