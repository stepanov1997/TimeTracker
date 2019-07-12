using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeTracker.Domain;

namespace TimeTracker.Models
{
    public class TimeEntryModel
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ClientName { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public DateTime EntryDate { get; set; }
        public int Hours { get; set; }
        public string Description { get; set; }
        public decimal HourRate { get; set; }
        public decimal Total => Hours * HourRate;

        private TimeEntryModel() { }
        public static TimeEntryModel FromUser(TimeEntry timeEntry)
        {
            return new TimeEntryModel()
            {
                ClientName = timeEntry.Project.Client.Name,
                Description = timeEntry.Description,
                EntryDate = timeEntry.EntryDate,
                HourRate = timeEntry.HourRate,
                Hours = timeEntry.Hours,
                Id = timeEntry.Id,
                ProjectId = timeEntry.Project.Id,
                ProjectName = timeEntry.Project.Name,
                UserId = timeEntry.Project.Client.Id,
                UserName = timeEntry.Project.Client.Name
            };
        }
    }
}
