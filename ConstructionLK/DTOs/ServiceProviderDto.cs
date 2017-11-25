using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ConstructionLK.Models;

namespace ConstructionLK.DTOs
{
    public class ServiceProviderDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        public byte MembershipTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(20)]

        public string BasedCity { get; set; }

        [Required]
        [StringLength(50)]

        public string MailingAddress { get; set; }

        [Required]

        public string Bio { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:y}")]
        //[Column(TypeName = "date")]
        //[Min18YearsIfAMember]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [StringLength(50)]
        public string Telephone { get; set; }

        [StringLength(50)]
        public string CompanyName { get; set; }

        [StringLength(20)]
        public string CompanyRegNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartedDate { get; set; }

        public string Avatar { get; set; }

        public int? Status { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public ServiceProviderTypeDto ServiceProviderType { get; set; }
        public int TypeId { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<BlogPost> BlogPosts { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Contact> Contacts { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ItemRequest> ItemRequests { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Item> Items { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<PublishedItem> PublishedItems { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<RatingsCustomer> RatingsCustomers { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<RatingsServiceProvider> RatingsServiceProviders { get; set; }
    }
}