﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using StackoverflowServer.Dtos;
using StackoverflowServer.Models;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using System.Data.Entity;

namespace StackoverflowServer.Controllers.api
{
    public class QuestionsController : ApiController
    {
        private ApplicationDbContext _context;

        public QuestionsController()
        {
            _context = new ApplicationDbContext();
        }

        [System.Web.Http.Route("api/GetQuestions")]
        public IEnumerable<QuestionDto> GetQuestions()
        {
            return _context.Questions.ToList().Select(Mapper.Map<Question, QuestionDto>);

            //return _context.Questions
            //    .Include(q => q.Answers.Select(a => a.AnswerTitle)).ToList().Select(Mapper.Map<Question, QuestionDto>);
        }

        [System.Web.Http.Route("api/GetQuestion/{id}")]
        public IHttpActionResult GetQuestion(long id)
        {
            //Question questionInDb = _context.Questions.FirstOrDefault(q => q.Id == id);

            var questionInDb = _context.Questions.Include(a => a.Answers.Select(b => b.AnswerTitle))
                .Where(q => q.Id == id).FirstOrDefault();

            if (questionInDb == null)
                return NotFound();

            return Ok(Mapper.Map<Question, QuestionDto>(questionInDb));
        }

        [HttpPost]
        [System.Web.Http.Route("api/CreateQuestion")]
        public IHttpActionResult CreateQuestion(QuestionDto questionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var question = Mapper.Map<QuestionDto, Question>(questionDto);
            _context.Questions.Add(question);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + question.Id), question);
        }

        [HttpPut]
        [System.Web.Http.Route("api/UpdateQuestion/{id}")]
        public void UpdateQuestion(QuestionDto questionDto, long id)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Question questionInDb = _context.Questions.SingleOrDefault(q => q.Id == id);

            if(questionInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //questionInDb.QuestionTitle = question.QuestionTitle;
            Mapper.Map(questionDto, questionInDb);

            _context.SaveChanges();
        }

        [HttpDelete]
        [System.Web.Http.Route("api/DeleteQuestion/{id}")]
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
