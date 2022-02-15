using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagement.Application.dtos.sprint
{
    class AddSprintResponseDto
    {
        public string Name { get; set; }
        public int SprintNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ProjectDto Project { get; set; }
    }
}
