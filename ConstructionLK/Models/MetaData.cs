using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionLK.Models
{
    public class MetaData
    {
        [Key]
        [Required]
        [StringLength(250)]
        public string Data { get; set; }

        [Required]
        [StringLength(250)]
        public string Value { get; set; }
    }
}