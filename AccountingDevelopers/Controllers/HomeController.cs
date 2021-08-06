using AccountingDevelopers.Models;
using AccountingDevelopersCore.DTO.Models;
using AccountingDevelopersCore.Infrastructure;
using AutoMapper;
using DevelopersAccountingDatabase.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountingDevelopers.Controllers
{
    [ApiController]
    [Route("api/home")]    
    public class HomeController : ControllerBase
    {
        private readonly DataManager _getDataManager;
        private readonly IMapper _mapper;
        public HomeController(DataManager getDataManager, IMapper mapper)
        {
            _getDataManager = getDataManager;
            _mapper = mapper;
        }
        [HttpGet]
        public IEnumerable<FullAccountingModel> Get()
        {
            var developersViewModel = _mapper.Map<List<DeveloperViewModel>>(_getDataManager.GetDeveloperDTOList());
            var projectsViewModel = _mapper.Map<List<ProjectViewModel>>(_getDataManager.GetProjectDTOList());           
            var fullAccountingModels = projectsViewModel.Join(developersViewModel,
                            p => p.Id, 
                            d => d.Id, 
                            (p, d) => new FullAccountingModel
                            {
                                ProjectId = p.Id,
                                ProjectName = p.ProjectName,
                                Description = p.Description,
                                DateOfCreate = p.DateOfCreate,
                                DeveloperId = d.Id,
                                FullName = $"{d.Name} {d.LastName}",
                                Position = d.Position
                            }).ToList();

            return fullAccountingModels;
        }
        //[HttpGet]
        //public IEnumerable<ProjectDTO> Get()
        //{
        //    return _getDataManager.GetProjectDTOList();
        //}
    }
}
