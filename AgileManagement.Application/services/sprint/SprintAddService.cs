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

        public bool OnProcess(AddSprintRequestDto request )
        {
            var project = _projectRepository.Find(request.ProjectId);
            var sprintCount = _projectRepository.GetQuery().Include(x => x.Sprints).SelectMany(a => a.Sprints).Count()+1;
            request.Name = $"Sprint-{sprintCount}";
            project.AddSprint(new Sprint(request.StartDate, request.EndDate,request.Name));
            try
            {
                _projectRepository.Save();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }
    }
}
