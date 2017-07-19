namespace Assignment7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWords : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Words",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Words = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Punctuations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Punctuations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.Words");
        }
    }
}
