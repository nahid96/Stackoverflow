namespace StackoverflowServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionDetailAddedToQuestionModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "QuestionTitle", c => c.String());
            AddColumn("dbo.Questions", "QuestionDetail", c => c.String());
            DropColumn("dbo.Questions", "QuestionTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "QuestionTitle", c => c.String());
            DropColumn("dbo.Questions", "QuestionDetail");
            DropColumn("dbo.Questions", "QuestionTitle");
        }
    }
}
