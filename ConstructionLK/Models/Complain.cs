using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConstructionLK.Models
{
    public class Complain
    {

        public int Id { get; set; }
        public DateTime ComplainedDate { get; set; }
        public ComplainAction ComplainAction { get; set; }
        public int ActionId { get; set; }
        public AspNetUser AspNetUser { get; set; }
        [StringLength(128)]
        public string ComplainedBy { get; set; }
        [StringLength(128)]
        public string ComplainedAbout { get; set; }

        public string ComplainBody { get; set; }
    }
}