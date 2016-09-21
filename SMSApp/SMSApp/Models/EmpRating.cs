using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMSApp.Models
{
    public class EmpRating
    {
        [Key]
        public int Id { get; set; }
        public string EmpEmail { get; set; }

        public string SkillName { get; set; }

        public string Rating { get; set; }
    }
}