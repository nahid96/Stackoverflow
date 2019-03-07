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
            new Question(){Id = 1, QuestionTitle = "Change X and Y axis font color", QuestionDetail = "How can I change the color of the X and Y axes labels? " +
                                                                                                      "I was trying to use fontColor within scaleLabel but I might be doing it in the wrong place ?" },
            new Question(){Id = 2, QuestionTitle = "changing column names with regular expressions using R", QuestionDetail = "I have a data frame with columns such as trial 1 trial 2 trial 3 trial 4 " +
                                                                                                                              "and I want to change them by adding the same word to each column like this" +
                                                                                                                              " x_trial 1 x_trial2 x_trial3 x_trial 4 Is there anyway I can do this using " +
                                                                                                                              "regular expressions instead of doing the following colnames(df) < -c(x_trial 1 x_trial2 x_trial3 x_trial 4) " +
                                                                                                                              "Thanks in advance"},
            new Question(){Id = 3, QuestionTitle = "How to subclass CollectionViewCell and change subclass Identifier programmatically?"},
            new Question(){Id = 4, QuestionTitle = "how download file post with casperjs?" }
                );

            context.Answers.AddOrUpdate(x => x.Id,
                new Answer() { Id = 1, AnswerTitle = "You can use fontColor inside ticks/label/legend:labels for a particular axis,", QuestionId = 1 },
                new Answer() { Id = 2, AnswerTitle = "if we set the options as below then the font color of axes label values changes. For example I tried it on jsfiddle and it worked. The same also worked for my chart in rails app. ...", QuestionId = 1},
                new Answer() { Id = 3, AnswerTitle = "I want to change them by adding the same word to each column like this x_trial 1 x_trial2 x_trial3 x_trial 4", QuestionId = 2 }

                );
        }
    }
}
