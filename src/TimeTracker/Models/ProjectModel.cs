using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeTracker.Domain;

namespace TimeTracker.Models
{
    public class ProjectModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ClientId { get; set; }
        public string ClientName { get; set; }

        private ProjectModel() { }
        public static ProjectModel FromUser(Project project)
        {
            return new ProjectModel()
            {
                ClientId = project.Client.Id,
                ClientName = project.Client.Name,
                Id= project.Id,
                Name = project.Name
            };
        }
    }
}
