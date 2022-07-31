using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PhonesAPI.DbContexts;
using PhonesAPI.Entities;

namespace PhonesAPI.Services
{
    public class LoggerRepository: ILoggerRepository
    {
        private readonly MakerPhoneContext _context;

        public LoggerRepository(MakerPhoneContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void LogInfo(string eventName)
        {
            _context.Logger.AddAsync(
                new LogEntry(eventName, LogLevel.Information)
                );

            _context.SaveChangesAsync();
        }

        public void LogWarn(string eventName)
        {
            _context.Logger.AddAsync(
                new LogEntry(eventName, LogLevel.Warning)
            );

            _context.SaveChangesAsync();
        }

        public void LogDebug(string eventName)
        {
            _context.Logger.AddAsync(
                new LogEntry(eventName, LogLevel.Debug)
            );

            _context.SaveChangesAsync();
        }

        public void LogError(string eventName)
        {
            _context.Logger.AddAsync(
                new LogEntry(eventName, LogLevel.Error)
            );

            _context.SaveChangesAsync();
        }

        public void LogCritical(string eventName)
        {
            _context.Logger.AddAsync(
                new LogEntry(eventName, LogLevel.Critical)
            );

            _context.SaveChangesAsync();
        }
    }
}
