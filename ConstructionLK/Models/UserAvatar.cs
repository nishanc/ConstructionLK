using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConstructionLK.Models
{
    public class UserAvatar
    {
        public int Id { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
        public int UserId { get; set; }
        public int Size { get; set; }
        public string Type { get; set; }
        public byte[] Content { get; set; }
    }
}