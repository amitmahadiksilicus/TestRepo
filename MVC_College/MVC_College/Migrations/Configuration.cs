namespace MVC_College.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MVC_College.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_College.Models.CollegeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVC_College.Models.CollegeContext context)
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

            context.Students.AddOrUpdate(i => i.StudentName,
                new Student
                {
                    StudentName = "When Harry Met Sally1",
                    StdandardId = 1,
                    ContactNumber="99999999"
                   
                },

                 new Student
                 {
                     StudentName = "When Harry Met Sally2",
                     StdandardId = 1,
                     ContactNumber = "99999999"
                 },

                 new Student
                 {
                     StudentName = "When Harry Met Sally3",
                     StdandardId = 1,
                     ContactNumber = "99999999"
                 },

               new Student
               {
                   StudentName = "When Harry Met Sally4",
                   StdandardId = 1,
                   ContactNumber = "99999999"
               }
           );
        }
    }
}
