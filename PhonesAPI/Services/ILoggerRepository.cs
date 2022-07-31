using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhonesAPI.Entities;

namespace PhonesAPI.Services
{
    public interface ILoggerRepository
    {
        void LogInfo(string eventName);
        void LogWarn(string eventName);
        void LogDebug(string eventName);
        void LogError(string eventName);
        void LogCritical(string eventName);
    }
}
