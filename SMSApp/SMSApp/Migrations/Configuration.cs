namespace SMSApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SMSApp.Dal;
    using SMSApp.Models; 
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<SkillManagementDal>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SkillManagementDal context)
        {
        

            

            context.Ratings.AddOrUpdate(
              p => p.RatingId,
              new Rating { RatingId = 1, RatingValue = 1 },
              new Rating { RatingId = 2, RatingValue = 2 },
              new Rating { RatingId = 3, RatingValue = 3 },
              new Rating { RatingId = 4, RatingValue = 4 },
              new Rating { RatingId = 5, RatingValue = 5 }
            );

            base.Seed(context);
        }
    }
}
