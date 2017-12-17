namespace ConstructionLK.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdministrativeStaff")]
    public partial class AdministrativeStaff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AdministrativeStaff()
        {
            ItemRequests = new HashSet<ItemRequest>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public int? CreatedBy { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }


        [Column(TypeName = "DateTime")]
        public DateTime ModifiedDate { get; set; }

        [StringLength(128)]
        public string ApplicationUserId { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemRequest> ItemRequests { get; set; }
    }
}
