using StackoverflowServer.Models;

namespace StackoverflowServer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StackoverflowServer.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "StackoverflowServer.Models.ApplicationDbContext";
        }

        protected override void Seed(StackoverflowServer.Models.ApplicationDbContext context)
        {
            context.Questions.AddOrUpdate(x => x.Id,
            new Question(){Id = 1, QuestionName = "Change X and Y axis font color"},
            new Question(){Id = 2, QuestionName = "changing column names with regular expressions using R"},
            new Question(){Id = 3, QuestionName = "How to subclass CollectionViewCell and change subclass Identifier programmatically?"},
            new Question(){Id = 4, QuestionName = "how download file post with casperjs?" }
                );
        }
    }
}
