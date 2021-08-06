using AccountingDevelopersCore.DTO.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingDevelopers.Models
{
    public class MappingProfileModel : Profile
    {
        public MappingProfileModel()
        {
            CreateMap<DeveloperViewModel, DeveloperDTO>();
            CreateMap<DeveloperDTO, DeveloperViewModel>();
            CreateMap<ProjectViewModel, ProjectDTO>();
            CreateMap<ProjectDTO, ProjectViewModel>();
        }
    }
}
