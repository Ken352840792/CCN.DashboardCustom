namespace CCN.DashboardCustom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreateChangeTableName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Employees", newName: "sy_employees");
            RenameColumn(table: "dbo.sy_employees", name: "CreationTime", newName: "CreateTime");
            RenameColumn(table: "dbo.sy_employees", name: "LastModificationTime", newName: "ModifyTime");
            RenameColumn(table: "dbo.sy_employees", name: "IsDeleted", newName: "Flag");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.sy_employees", name: "Flag", newName: "IsDeleted");
            RenameColumn(table: "dbo.sy_employees", name: "ModifyTime", newName: "LastModificationTime");
            RenameColumn(table: "dbo.sy_employees", name: "CreateTime", newName: "CreationTime");
            RenameTable(name: "dbo.sy_employees", newName: "Employees");
        }
    }
}
