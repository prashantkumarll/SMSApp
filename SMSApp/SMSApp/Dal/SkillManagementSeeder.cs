using SMSApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SMSApp.Dal
{
    public class SkillManagementSeeder:DropCreateDatabaseIfModelChanges<SkillManagementDal>
    {
        protected override void Seed(SkillManagementDal context)
        {            
            Skill skill1 = new Skill()
            {
                SkillId = 1,
                SkillName = "C Sharp"
            };
            Skill skill2 = new Skill()
            {
                SkillId = 2,
                SkillName = "Javascript"
            };
            Skill skill3 = new Skill()
            {
                SkillId = 3,
                SkillName = "Jquery"
            };
            Skill skill4 = new Skill()
            {
                SkillId = 4,
                SkillName = "BootStrap"
            };
            Skill skill5 = new Skill()
            {
                SkillId = 5,
                SkillName = "Linq"
            };
            context.Skills.Add(skill1);
            context.Skills.Add(skill2);
            context.Skills.Add(skill3);
            context.Skills.Add(skill4);
            context.Skills.Add(skill5);

            Rating rating1 = new Rating()
            {
                RatingId = 1,
                RatingValue = 1
            };
            Rating rating2 = new Rating()
            {
                RatingId = 2,
                RatingValue = 2
            };
            Rating rating3 = new Rating()
            {
                RatingId = 3,
                RatingValue = 3
            };
            Rating rating4 = new Rating()
            {
                RatingId = 4,
                RatingValue = 4
            };
            Rating rating5 = new Rating()
            {
                RatingId = 5,
                RatingValue = 5
            };

            context.Ratings.Add(rating1);
            context.Ratings.Add(rating2);
            context.Ratings.Add(rating3);
            context.Ratings.Add(rating4);
            context.Ratings.Add(rating5);
            base.Seed(context); 
        }
    }
}