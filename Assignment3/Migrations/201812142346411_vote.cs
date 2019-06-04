namespace Assignment3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vote", "VoteUp", c => c.Boolean(nullable: false));
            AddColumn("dbo.Vote", "VoteDown", c => c.Boolean(nullable: false));
            DropColumn("dbo.Vote", "VoteUpDown");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vote", "VoteUpDown", c => c.Boolean(nullable: false));
            DropColumn("dbo.Vote", "VoteDown");
            DropColumn("dbo.Vote", "VoteUp");
        }
    }
}
