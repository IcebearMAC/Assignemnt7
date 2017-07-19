namespace Assignment7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpunctuation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Punctuations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Punctuations");
        }
    }
}
