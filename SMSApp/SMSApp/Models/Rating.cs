using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMSApp.Models
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }
        public int RatingValue { get; set; }
    }
}