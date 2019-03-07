using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackoverflowServer.Models
{
    public class Question
    {
        public long Id { get; set; }

        public string QuestionTitle { get; set; }

        public string QuestionDetail { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}