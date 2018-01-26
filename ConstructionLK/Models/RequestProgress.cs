using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name="Current Progress(%)")]
        public int value { get; set; }
        public string Comment { get; set; }
    }
}