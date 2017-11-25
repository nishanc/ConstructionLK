using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConstructionLK.Models;

namespace ConstructionLK.ViewModels
{
    public class NewServiceProviderViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public IEnumerable<ServiceProviderType> ServiceProviderTypes { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
    }
}