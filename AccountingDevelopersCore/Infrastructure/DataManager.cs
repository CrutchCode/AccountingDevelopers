using AccountingDevelopersCore.DTO.Models;
using AutoMapper;
using DevelopersAccountingDatabase.Interfaces;
using DevelopersAccountingDatabase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
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


        public async Task AddDevelopersToProject(int projectId, int developerId)
        {
            var project = await _projectRepository.GetProjectAsync(projectId);
            var developer = await _developerRepository.GetDeveloperAsync(developerId);
            project.Developers.Add(developer);
            await _projectRepository.SaveAsync();
            developer.Projects.Add(project);
            await _developerRepository.SaveAsync();
        }

        public IEnumerable<FullDTO> AccountingData()
        {
            var projects = _projectRepository.GetProjectList();
            var developers = _developerRepository.GetDeveloperList();
            return developers.SelectMany(d => d.Projects, (d, p) => new { Developer = d, Project = p})
                            .Join(projects, d => d.Project.Id, p => p.Id,(d,p) => new FullDTO
                            { 
                                ProjectId = p.Id,
                                ProjectName = p.ProjectName,
                                Description = p.Description,
                                DateOfCreate = p.DateOfCreate,
                                DeveloperId = d.Developer.Id,
                                FullName = $"{d.Developer.Name} {d.Developer.LastName}",
                                Position = d.Developer.Position
                            }).ToList();
        }

        public IEnumerable<FullDTO> ManageData()
        {
            var projects = _projectRepository.GetProjectList();
            var developers = _developerRepository.GetDeveloperList();
            //return projects.SelectMany(p => p.Developers, (p, d) => new { Developer = d, Project = p })
            //                .GroupJoin(developers, d => d.Developer.Id, p => p.Id, (p, d) => new { Obj = p, CollDevelopers = d })
            //                .SelectMany(u => u.CollDevelopers.DefaultIfEmpty(), (d, u) => new FullDTO
            //                {
            //                    ProjectId = d.Obj.Project.Id,
            //                    ProjectName = d.Obj.Project.ProjectName,
            //                    Description = d.Obj.Project.Description,
            //                    DateOfCreate = d.Obj.Project.DateOfCreate,
            //                    DeveloperId = u.Id,
            //                    FullName = $"{u.Name} {u.LastName}",
            //                    Position = u.Position
            //                })
            //                .ToList();
            return developers.SelectMany(d => d.Projects, (d, p) => new { Developer = d, Project = p })
                           .Join(projects, d => d.Project.Id, p => p.Id, (d, p) => new FullDTO
                           {
                               ProjectId = p.Id,
                               ProjectName = p.ProjectName,
                               Description = p.Description,
                               DateOfCreate = p.DateOfCreate,
                               DeveloperId = d.Developer.Id,
                               FullName = $"{d.Developer.Name} {d.Developer.LastName}",
                               Position = d.Developer.Position
                           }).ToList();
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
