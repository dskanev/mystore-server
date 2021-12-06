﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infrastructure
{
    public static class ConfigurationExtensions
    {
        public static string GetDefaultConnectionString(this IConfiguration configuration)
        {
            return configuration.GetConnectionString("DefaultConnection");
        }
    }
}
