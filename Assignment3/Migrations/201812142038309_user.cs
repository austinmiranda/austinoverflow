namespace Assignment3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vote",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.String(nullable: false),
                        VoteStatus = c.Boolean(nullable: false),
                        VoteUpDown = c.Boolean(nullable: false),
                        Question_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Question", t => t.Question_Id, cascadeDelete: true)
                .Index(t => t.Question_Id);
            
            AddColumn("dbo.Answer", "User_Id", c => c.String(nullable: false));
            AddColumn("dbo.Answer", "UserName", c => c.String(nullable: false));
            AddColumn("dbo.Question", "User_Id", c => c.String(nullable: false));
            AddColumn("dbo.Question", "UserName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vote", "Question_Id", "dbo.Question");
            DropIndex("dbo.Vote", new[] { "Question_Id" });
            DropColumn("dbo.Question", "UserName");
            DropColumn("dbo.Question", "User_Id");
            DropColumn("dbo.Answer", "UserName");
            DropColumn("dbo.Answer", "User_Id");
            DropTable("dbo.Vote");
        }
    }
}
