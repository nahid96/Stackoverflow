using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StackoverflowServer.Dtos;
using StackoverflowServer.Models;


namespace StackoverflowServer.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Question, QuestionDto>();
            Mapper.CreateMap<QuestionDto, Question>();
        }
    }
}