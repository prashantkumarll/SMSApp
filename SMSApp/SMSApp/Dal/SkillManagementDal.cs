using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SMSApp.Models;

namespace SMSApp.Dal
{
    public class SkillManagementDal:DbContext
    {
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<EmpRating> EmpRatings { get; set; }      

    }
}