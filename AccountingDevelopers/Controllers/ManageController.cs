using AccountingDevelopers.Models;
using AccountingDevelopersCore.DTO.Models;
using AccountingDevelopersCore.Infrastructure;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountingDevelopers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageController : ControllerBase
    {
        private readonly DataManager _dataManage;
        private readonly IMapper _mapper;
        public ManageController(DataManager dataManage, IMapper mapper)
        {
            _dataManage = dataManage;
            _mapper = mapper;
        }

        // GET: api/<ServiceController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "string" };
        }

        // GET api/<ServiceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ServiceController>
        [HttpPost]
        public void Post()
        {
            
        }

        // PUT api/<ServiceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ServiceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
