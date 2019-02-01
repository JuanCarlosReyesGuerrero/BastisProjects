namespace Bastis.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        CustomerID = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 128),
                        LastName = c.String(nullable: false, maxLength: 128),
                        Address = c.String(nullable: false, maxLength: 128),
                        EmploymentCharge = c.String(nullable: false, maxLength: 128),
                        Expirience = c.String(),
                        Email = c.String(nullable: false, maxLength: 128),
                        Phone = c.String(),
                        Mobile = c.String(nullable: false, maxLength: 128),
                        AboutMe = c.String(nullable: false, maxLength: 128),
                        SocialNetworks = c.String(nullable: false, maxLength: 128),
                        Website = c.String(),
                        ProfilePicture = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Agents");
        }
    }
}
