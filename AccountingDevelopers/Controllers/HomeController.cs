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
            return _mapper.Map<List<FullAccountingModel>>(_getDataManager.AccountingData());
        }
    }
}
