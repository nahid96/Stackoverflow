namespace StackoverflowServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteQuestionId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            RenameColumn(table: "dbo.Answers", name: "QuestionId", newName: "Question_Id");
            AlterColumn("dbo.Answers", "Question_Id", c => c.Long());
            CreateIndex("dbo.Answers", "Question_Id");
            AddForeignKey("dbo.Answers", "Question_Id", "dbo.Questions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "Question_Id", "dbo.Questions");
            DropIndex("dbo.Answers", new[] { "Question_Id" });
            AlterColumn("dbo.Answers", "Question_Id", c => c.Long(nullable: false));
            RenameColumn(table: "dbo.Answers", name: "Question_Id", newName: "QuestionId");
            CreateIndex("dbo.Answers", "QuestionId");
            AddForeignKey("dbo.Answers", "QuestionId", "dbo.Questions", "Id", cascadeDelete: true);
        }
    }
}
