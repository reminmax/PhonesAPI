using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace PhonesAPI.Entities
{
    public class LogEntry
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        public string EventName { get; set; }

        [Required]
        public LogLevel LogLevel { get; set; }

        public LogEntry(string eventName, LogLevel logLevel)
        {
            EventName = eventName;
            LogLevel = logLevel;
            EventDate = DateTime.Now;
        }
    }
}
