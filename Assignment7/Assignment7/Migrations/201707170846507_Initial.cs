namespace Assignment7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PictureName = c.String(),
                        AnimalName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Punctuations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TestDate = c.DateTime(nullable: false),
                        Category = c.Int(nullable: false),
                        AmountOfQuestions = c.Int(nullable: false),
                        AmountOfRightAnswers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Scores");
            DropTable("dbo.Punctuations");
            DropTable("dbo.Pictures");
            DropTable("dbo.Colors");
        }
    }
}
