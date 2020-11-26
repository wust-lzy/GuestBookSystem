namespace GuestBookSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Name = c.String(),
                        Password = c.String(),
                        SRole = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            AddColumn("dbo.Guestbooks", "IsPass", c => c.Boolean(nullable: false));
            AddColumn("dbo.Guestbooks", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Guestbooks", "UserId");
            AddForeignKey("dbo.Guestbooks", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Guestbooks", "UserId", "dbo.Users");
            DropIndex("dbo.Guestbooks", new[] { "UserId" });
            DropColumn("dbo.Guestbooks", "UserId");
            DropColumn("dbo.Guestbooks", "IsPass");
            DropTable("dbo.Users");
        }
    }
}
