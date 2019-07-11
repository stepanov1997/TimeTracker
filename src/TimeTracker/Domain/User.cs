using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Domain
{
    public class User
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal HourRate { get; set; }
    }
}
