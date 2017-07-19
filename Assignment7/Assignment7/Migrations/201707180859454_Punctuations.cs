namespace Assignment7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Punctuations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Punctuations", "Text", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Punctuations", "Text", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
