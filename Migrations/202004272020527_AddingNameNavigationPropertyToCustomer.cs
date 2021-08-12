namespace MovieApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingNameNavigationPropertyToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "membershipNameId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "membershipName_Id", c => c.Byte());
            CreateIndex("dbo.Customers", "membershipName_Id");
            AddForeignKey("dbo.Customers", "membershipName_Id", "dbo.MembershipTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "membershipName_Id", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "membershipName_Id" });
            DropColumn("dbo.Customers", "membershipName_Id");
            DropColumn("dbo.Customers", "membershipNameId");
        }
    }
}
