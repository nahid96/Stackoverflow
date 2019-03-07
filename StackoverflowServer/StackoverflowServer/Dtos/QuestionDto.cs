using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StackoverflowServer.Models;

namespace StackoverflowServer.Dtos
{
    public class QuestionDto
    {
        public long Id { get; set; }

        public string QuestionTitle { get; set; }

        public string QuestionDetail { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}