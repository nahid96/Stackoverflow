using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackoverflowServer.Dtos
{
    public class QuestionDto
    {
        public long Id { get; set; }

        public string QuestionName { get; set; }
    }
}