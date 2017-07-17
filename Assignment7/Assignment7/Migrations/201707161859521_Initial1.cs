namespace Assignment7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pictures", "PictureName", c => c.String());
            AddColumn("dbo.Pictures", "AnimalName", c => c.String());
            DropColumn("dbo.Pictures", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pictures", "Name", c => c.String());
            DropColumn("dbo.Pictures", "AnimalName");
            DropColumn("dbo.Pictures", "PictureName");
        }
    }
}
