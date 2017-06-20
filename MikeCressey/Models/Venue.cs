using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MikeCressey.Models
{
    public class Venue
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }

        [Required]
        [StringLength(80)]
        [Column(TypeName = "varchar")]
        public string Street { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string City { get; set; }

        [Required]
        [StringLength(20)]
        [Column(TypeName = "varchar")]
        public string State { get; set; }

        [Required]
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string Zipcode { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Gig> Gigs { get; set; }
    }
}