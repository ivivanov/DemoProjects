namespace LinqTests.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LinqTests.BarsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LinqTests.BarsDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Bars.AddOrUpdate(
                x => x.Id,
                new Bar() { OpeningDay = DateTime.Now.AddDays(-2), Thursday = true, Name = "Paddy's", OpenWeekDays = 1 },
                new Bar() { OpeningDay = DateTime.Now.AddDays(-1), Thursday = false, Name = "Walker's", OpenWeekDays = 1 },
                new Bar() { OpeningDay = DateTime.Now.AddDays(-1), Thursday = true, Name = "Jhonny's", OpenWeekDays = 1 },
                new Bar() { OpeningDay = DateTime.Now.AddDays(+1), Thursday = true, Name = "Chivas's", OpenWeekDays = 1 }
            );
        }
    }
}
