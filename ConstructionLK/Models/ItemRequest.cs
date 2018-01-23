namespace ConstructionLK.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ItemRequest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ItemRequest()
        {
            ItemPayments = new HashSet<ItemPayment>();
            //Locations = new HashSet<Location>();
            RatingsCustomers = new HashSet<RatingsCustomer>();
            RatingsServiceProviders = new HashSet<RatingsServiceProvider>();
            AdministrativeStaffs = new HashSet<AdministrativeStaff>();
        }

        public int Id { get; set; }

        [StringLength(250)]
        [Display(Name = "Message(Optional, Maximum 250 Characters)")]
        public string Message { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? AcceptedDate { get; set; }

        public DateTime? ExpDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        public int? StatusId { get; set; }
        public virtual ItemRequestStatus ItemRequestStatus { get; set; }

        public int LocationId { get; set; }

        public int CustomerId { get; set; }

        public int ServiceProviderId { get; set; }

        public int ItemId { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemPayment> ItemPayments { get; set; }

        public virtual Item Item { get; set; }

        public virtual Location Location { get; set; }

        public virtual ServiceProvider ServiceProvider { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Location> Locations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RatingsCustomer> RatingsCustomers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RatingsServiceProvider> RatingsServiceProviders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdministrativeStaff> AdministrativeStaffs { get; set; }
        
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
    }
}
