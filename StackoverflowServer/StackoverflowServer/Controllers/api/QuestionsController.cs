using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using StackoverflowServer.Models;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

namespace StackoverflowServer.Controllers.api
{
    public class QuestionsController : ApiController
    {
        private ApplicationDbContext _context;

        public QuestionsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Question> GetQuestions()
        {
            return _context.Questions.ToList();
        }

        public Question GetQuestion(long id)
        {
            Question questionInDb = _context.Questions.SingleOrDefault(q => q.Id == id);

            if(questionInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return questionInDb;
        }

        [HttpPost]
        public Question CreateQuestion(Question question)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Questions.Add(question);
            _context.SaveChanges();

            return question;
        }

        [HttpPut]
        public void UpdateQuestion(Question question, long id)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Question questionInDb = _context.Questions.SingleOrDefault(q => q.Id == id);

            if(questionInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            questionInDb.QuestionName = question.QuestionName;

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteQuestion(long id)
        {
            Question questionInDb = _context.Questions.SingleOrDefault(q => q.Id == id);

            if(questionInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Questions.Remove(questionInDb);

            _context.SaveChanges();
        }
    }
}
