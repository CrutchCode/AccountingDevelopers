using AccountingDevelopersCore.DTO.Models;
using AutoMapper;
using DevelopersAccountingDatabase.Interfaces;
using DevelopersAccountingDatabase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountingDevelopersCore.Infrastructure
{
    public class DataManager
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IDeveloperRepository _developerRepository;
        private readonly IMapper _mapper;
        public DataManager(IProjectRepository projectRepository, IDeveloperRepository developerRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _developerRepository = developerRepository;
            _mapper = mapper;
        }

        public async Task<ProjectDTO> GetProjectDTOAsync(int id)
        {
            var project = await _projectRepository.GetProjectAsync(id);
            var projectDto = _mapper.Map<ProjectDTO>(project);
            return projectDto;
        }
        public IEnumerable<ProjectDTO> GetProjectDTOList()
        {
            var projects = _projectRepository.GetProjectList();
            var projectsDto = _mapper.Map<List<ProjectDTO>>(projects);
            return projectsDto;
        }
        public async Task CreateProjectDTO(ProjectDTO projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);
            await _projectRepository.CreateAsync(project);
        }
        public async Task DeleteProjectDTOAsync(int id)
        {
            await _projectRepository.DeleteAsync(id);
        }
        public async Task SaveProjectDTOAsync()
        {
            await _projectRepository.SaveAsync();
        }
        public void UpdateProjectDTO(ProjectDTO projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);
            _projectRepository.Update(project);
        }



        public async Task<DeveloperDTO> GetDeveloperDTOAsync(int id)
        {
            var developer = await _developerRepository.GetDeveloperAsync(id);
            var developerDto = _mapper.Map<DeveloperDTO>(developer);
            return developerDto;
        }
        public IEnumerable<DeveloperDTO> GetDeveloperDTOList()
        {
            var developers = _developerRepository.GetDeveloperList();
            var developersDto = _mapper.Map<List<DeveloperDTO>>(developers);
            return developersDto;
        }
        public async Task CreateDeveloperDTOAsync(DeveloperDTO developerDto)
        {
            var developer = _mapper.Map<Developer>(developerDto);
            await _developerRepository.CreateAsync(developer);
        }
        public async Task DeleteDeveloperDTOAsync(int id)
        {
            await _developerRepository.DeleteAsync(id);
        }
        public async Task SaveDeveloperDTOAsync()
        {
            await _developerRepository.SaveAsync();
        }
        public void UpdateDeveloperDTO(DeveloperDTO developerDto)
        {
            var developer = _mapper.Map<Developer>(developerDto);
            _developerRepository.Update(developer);
        }
        
    }
}
