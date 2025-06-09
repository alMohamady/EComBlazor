﻿using EComBlazor.lib.Base;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComBlazor.lib.Services
{
    public class SerilogAppAdapter<T>(ILogger<T> logger) : IAppLoger<T> where T : class
    {
        public void LogError(Exception ex, string message)
        {
            logger.LogError(ex, message);
        }

        public void LogInfo(string message)
        {
            logger.LogWarning(message);
        }

        public void LoginInformation(string message)
        {
            logger.LogInformation(message);
        }
    }
}
