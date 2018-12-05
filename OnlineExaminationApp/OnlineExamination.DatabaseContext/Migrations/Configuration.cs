namespace OnlineExamination.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineExamination.DatabaseContext.DatabaseContext.OnlineExaminationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "OnlineExamination.DatabaseContext.DatabaseContext.OnlineExaminationDbContext";
        }

        protected override void Seed(OnlineExamination.DatabaseContext.DatabaseContext.OnlineExaminationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
