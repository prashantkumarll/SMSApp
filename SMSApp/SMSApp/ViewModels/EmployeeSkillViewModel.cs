using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMSApp.Models;

namespace SMSApp.ViewModels
{
    public class EmployeeSkillViewModel
    {
        public Rating ratings { get; set; }    
        public Skill skills { get; set; }
        public List<EmpRating> empRatings { get; set; }

    }
}