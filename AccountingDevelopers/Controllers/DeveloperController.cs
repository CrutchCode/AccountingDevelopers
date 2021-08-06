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
    public class DeveloperController : ControllerBase
    {
        private readonly DataManager _dataManage;
        private readonly IMapper _mapper;
        public DeveloperController(DataManager dataManage, IMapper mapper)
        {
            _dataManage = dataManage;
            _mapper = mapper;
        }

        // GET: api/<DeveloperController>
        [HttpGet]
        public IEnumerable<DeveloperViewModel> Get()
        {
            return _mapper.Map<List<DeveloperViewModel>>(_dataManage.GetDeveloperDTOList());
        }

        [HttpGet]
        [Route("group")]
        public IEnumerable<string> GetGroup()
        {
            var temp = _mapper.Map<List<DeveloperViewModel>>(_dataManage.GetDeveloperDTOList()).GroupBy(d => d.Position);

            List<string> tempList = new List<string>();
            foreach (var item in temp)
            {
                tempList.Add(item.Key);
            }
            return tempList;

        }

        // GET api/<DeveloperController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<DeveloperController>
        [HttpPost]
        public async Task<ActionResult> Post(DeveloperViewModel developer)
        {
            await _dataManage.CreateDeveloperDTOAsync(_mapper.Map<DeveloperDTO>(developer));
            await _dataManage.SaveDeveloperDTOAsync();
            return Ok(developer);
        }

        // PUT api/<DeveloperController>/5
        [HttpPut]
        public async Task<ActionResult> Put(DeveloperViewModel developer)
        {
            _dataManage.UpdateDeveloperDTO(_mapper.Map<DeveloperDTO>(developer));
            await _dataManage.SaveDeveloperDTOAsync();
            return Ok(developer);
        }

        // DELETE api/<DeveloperController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var developer = await _dataManage.GetDeveloperDTOAsync(id);
            await _dataManage.DeleteDeveloperDTOAsync(developer.Id);
            await _dataManage.SaveDeveloperDTOAsync();
            return Ok(developer);
        }
    }
}
