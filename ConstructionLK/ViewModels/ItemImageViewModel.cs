using ConstructionLK.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConstructionLK.ViewModels
{
    public class ItemImageViewModel
    {

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemId { get; set; }

        [Required]
        public string Image { get; set; }

        public virtual Item Item { get; set; }
        public byte[] ImageData { get; set; }

        [Required(ErrorMessage = "Please select image file")]
        public HttpPostedFileBase File { get; set; }
    }
}