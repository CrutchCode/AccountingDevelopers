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
    public class ProjectController : ControllerBase
    {
        private readonly DataManager _dataManage;
        private readonly IMapper _mapper;
        public ProjectController(DataManager dataManage, IMapper mapper)
        {
            _dataManage = dataManage;
            _mapper = mapper; 
        }
        // GET: api/<ProjectController>
        [HttpGet]
        public IEnumerable<ProjectViewModel> Get()
        {
            return _mapper.Map<List<ProjectViewModel>>(_dataManage.GetProjectDTOList());
        }

        // GET api/<ProjectController>/5
        //[HttpGet("{id}")]
        //public async Task<ProjectViewModel> Get(int id)
        //{
        //    return _mapper.Map<ProjectViewModel>(await _dataManage.GetProjectDTOAsync(id));
        //}

        [HttpGet("{sort}")]
        public IEnumerable<ProjectViewModel> Get(bool sort)
        {
            if (sort)
            {
                return _mapper.Map<List<ProjectViewModel>>(_dataManage.GetProjectDTOList()).OrderByDescending(p=>p.ProjectName);
            }
            return _mapper.Map<List<ProjectViewModel>>(_dataManage.GetProjectDTOList()).OrderBy(p=>p.ProjectName);

        }

        [HttpGet]
        [Route("group")]
        public IEnumerable<string> GetGroup()
        {
            var temp = _mapper.Map<List<ProjectViewModel>>(_dataManage.GetProjectDTOList()).GroupBy(p => p.Description);
            
            List<string> tempList = new List<string>();
            foreach (var item in temp)
            {
                tempList.Add(item.Key);
            }
            return tempList;

        }

        // POST api/<ProjectController>
        [HttpPost]
        public async Task<ActionResult> Post(ProjectViewModel projectViewModel)
        {
            await _dataManage.CreateProjectDTO(_mapper.Map<ProjectDTO>(projectViewModel));
            await _dataManage.SaveProjectDTOAsync();
            return Ok(projectViewModel);
        }

        // PUT api/<ProjectController>/5
        [HttpPut]
        public async Task<ActionResult> Put(ProjectViewModel projectViewModel)
        {
            _dataManage.UpdateProjectDTO(_mapper.Map<ProjectDTO>(projectViewModel));
            await _dataManage.SaveProjectDTOAsync();
            return Ok(projectViewModel);
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var project = await _dataManage.GetProjectDTOAsync(id);
            await _dataManage.DeleteProjectDTOAsync(project.Id);
            await _dataManage.SaveProjectDTOAsync();
            return Ok(project);
        }
    }
}
