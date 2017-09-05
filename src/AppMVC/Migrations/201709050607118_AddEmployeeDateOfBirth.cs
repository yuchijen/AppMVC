namespace AppMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddEmployeeDateOfBirth : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TblEmployee", "DateOfBirth", c => c.DateTime(nullable: true));
        }

        public override void Down()
        {
            DropColumn("dbo.TblEmployee", "DateOfBirth");
        }
    }
}
