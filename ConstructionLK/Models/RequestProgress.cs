using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConstructionLK.Models
{
    public class RequestProgress
    {
        public int Id { get; set; }
        public ItemRequest ItemRequest { get; set; }
        public int ReqId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int value { get; set; }
        public string Comment { get; set; }
    }
}