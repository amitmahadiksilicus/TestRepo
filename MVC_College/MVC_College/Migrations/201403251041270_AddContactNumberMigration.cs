namespace MVC_College.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContactNumberMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "ContactNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "ContactNumber");
        }
    }
}
