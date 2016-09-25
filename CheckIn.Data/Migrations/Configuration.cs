using CheckIn.Data.Entities;

namespace CheckIn.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CheckIn.Data.CheckInDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CheckIn.Data.CheckInDb context)
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
            /*context.Admins.AddOrUpdate(
                  //new Person { FullName = "Andrew Peters" },
                  //new Person { FullName = "Brice Lambson" },
                  new Admin { Name = "Pavan Gonagur", Email = "p@v.com", Password = "p", PhoneNumber = "1234567890" }
                );*/
        }
    }
}
