using AutoMapper;
using OLSoftware.Application.DTO;
using OLSoftware.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OLSoftware.Transversal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Project, ProjectDTO>().ReverseMap();
            CreateMap<ProgrammingLanguages, ProgrammingLanguagesDTO>().ReverseMap();
            CreateMap<LanguagesByProject, ProgrammingLanguagesbyProjectDTO>().ReverseMap();            
        }
    }
}
