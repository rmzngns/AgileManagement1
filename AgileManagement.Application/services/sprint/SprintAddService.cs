using AgileManagement.Core;
using AgileManagement.Domain;
using AgileManagement.Domain.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagement.Application
{ 
    public class SprintAddService : ISprintAddService
    {
        IProjectRepository _projectRepository;

        public SprintAddService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public SprintDto OnProcess(AddSprintRequestDto request)
        {
            var project = _projectRepository.Find(request.ProjectId);
            if (project == null)
            {
                throw new Exception("Seçili Proje bulunamadı");
            }
            else
            {
                var sprintCount = _projectRepository.GetQuery().Include(x => x.Sprints).SelectMany(a => a.Sprints).Count() + 1;
                request.Name = $"Sprint-{sprintCount}";
                project.AddSprint(new Sprint(request.StartDate, request.EndDate, request.Name));
                _projectRepository.Save();
                

                var response = new SprintDto { Name = request.Name, StartDate = request.StartDate, EndDate = request.EndDate };
                return response;
            }
        }
    }
}
