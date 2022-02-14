using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagement.Application.dtos.sprint
{
    public class AddSprintRequestDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public int StringId { get; set; }
        public ProjectDto Project { get; set; }
    }
}
