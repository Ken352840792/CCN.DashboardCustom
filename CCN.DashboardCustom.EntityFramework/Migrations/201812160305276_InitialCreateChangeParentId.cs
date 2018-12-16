namespace CCN.DashboardCustom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreateChangeParentId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.sy_employees", "ParentId", c => c.Guid());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.sy_employees", "ParentId", c => c.Guid(nullable: false));
        }
    }
}
