namespace MVC_College.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(nullable: false),
                        StdandardId = c.Int(nullable: false),
                        Standard_StandardId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Standards", t => t.Standard_StandardId)
                .Index(t => t.Standard_StandardId);
            
            CreateTable(
                "dbo.Standards",
                c => new
                    {
                        StandardId = c.Int(nullable: false, identity: true),
                        StandardName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.StandardId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Students", new[] { "Standard_StandardId" });
            DropForeignKey("dbo.Students", "Standard_StandardId", "dbo.Standards");
            DropTable("dbo.Standards");
            DropTable("dbo.Students");
        }
    }
}
