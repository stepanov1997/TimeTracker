using System;
using System.Security.Cryptography;
using TimeTracker.Domain;

namespace TimeTracker.Models
{
    public class TimeEntryInputModel
    {
        public long ProjectId { get; set; }
        public long UserId { get; set; }
        public DateTime EntryDate { get; set; }
        public int Hours { get; set; }
        public string Description { get; set; }

        public void MapTo(TimeEntry timeEntry)
        {
            ProjectId = timeEntry.Project.Id;
            UserId = timeEntry.User.Id;
            EntryDate = timeEntry.EntryDate;
            Hours = timeEntry.Hours;
            Description = timeEntry.Description;
        }
    }
}