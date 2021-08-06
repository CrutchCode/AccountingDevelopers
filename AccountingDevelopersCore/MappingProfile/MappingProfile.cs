using AccountingDevelopersCore.DTO.Models;
using AutoMapper;
using DevelopersAccountingDatabase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingDevelopersCore.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DeveloperDTO, Developer>();
            CreateMap<Developer, DeveloperDTO>();
            CreateMap<ProjectDTO, Project>();
            CreateMap<Project, ProjectDTO>();
        }
    }
}
