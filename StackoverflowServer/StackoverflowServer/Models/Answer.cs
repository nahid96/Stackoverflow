using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackoverflowServer.Models
{
    public class Answer
    {
        public long Id { get; set; }

        public string AnswerTitle { get; set; }

        public long QuestionId { get; set; }
    }
}