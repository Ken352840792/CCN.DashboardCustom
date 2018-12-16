using System.Data.Entity.Migrations;

namespace CCN.DashboardCustom.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DashboardCustom";
        }

        protected override void Seed(DBContext context)
        {
            
            base.Seed(context);
        }
    }
}
