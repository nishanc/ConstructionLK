namespace ConstructionLK.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            BlogPostComments = new HashSet<BlogPostComment>();
            ItemComments = new HashSet<ItemComment>();
            ItemRequests = new HashSet<ItemRequest>();
            CustomerCurrentLocations = new HashSet<CustomerCurrentLocation>();
            RatingsCustomers = new HashSet<RatingsCustomer>();
            RatingsServiceProviders = new HashSet<RatingsServiceProvider>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:y}")]
        [Display(Name = "Date of Birth")]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Your must provide a Phone Number")]
        [Display(Name = "Home Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string Telephone { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        [Required]
        public string Address { get; set; }

        public int? StatusId { get; set; }

        public virtual Status Status { get; set; }

        public int? CreatedBy { get; set; }
        [Column(TypeName = "DateTime")]
        //[DisplayFormat(DataFormatString = "{0:y}")]
        public DateTime CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime ModifiedDate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }


        [StringLength(128)]
        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual AspNetUser AspNetUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BlogPostComment> BlogPostComments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemComment> ItemComments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemRequest> ItemRequests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RatingsCustomer> RatingsCustomers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RatingsServiceProvider> RatingsServiceProviders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerCurrentLocation> CustomerCurrentLocations { get; set; }
    }
}
