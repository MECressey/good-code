using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MikeCressey.Models
{
    public class Gig
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Gig Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime GigDate { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:t}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        [Display(Name = "End Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:t}")]
        public DateTime EndTime { get; set; }

        public string Details { get; set; }

        [Required]
        public int VenueId { get; set; }
        public virtual Venue Venue { get; set; }
    }
}