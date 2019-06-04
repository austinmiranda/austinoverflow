namespace Assignment3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vote_removestatus : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vote", "VoteStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vote", "VoteStatus", c => c.Boolean(nullable: false));
        }
    }
}
