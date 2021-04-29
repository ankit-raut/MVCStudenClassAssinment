namespace MVCStudenClassAssinment.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCStudenClassAssinment.DAL.ApplicationDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MVCStudenClassAssinment.DAL.ApplicationDBContext";
        }

        protected override void Seed(MVCStudenClassAssinment.DAL.ApplicationDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
