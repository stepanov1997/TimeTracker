using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Domain
{
    public class Project
    {
        public long Id { get; set; }

        [Required] public string Name { get; set; }

        public Client Client { get; set; }
    }
}