using AgileManagement.Core;
using AgileManagement.Domain;
using AgileManagement.Domain.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagement.Application.services.sprint
{
    public class SprintAddService : ISprintAddService
    {
        IProjectRepository _projectRepository;

        public SprintAddService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public ProjectDto OnProcess(AddSprintRequestDto request )
        {
            var project = _projectRepository.Find(request.ProjectId);
            var sprintCount = _projectRepository.GetQuery().Include(x => x.Sprints).SelectMany(a => a.Sprints).Count()+1;
            request.Name = $"Sprint-{sprintCount}";
            project.AddSprint(new Sprint(request.StartDate, request.EndDate,request.Name));
            
            var response=_projectRepository.GetQuery().Include(x=>x.Sprints).Where(x=>x.Id==request.ProjectId).Select(a=>new ProjectDto
            {

                Name=a.Name,
                 Description=a.Description,
                 

            })
            
        }
    }
}
