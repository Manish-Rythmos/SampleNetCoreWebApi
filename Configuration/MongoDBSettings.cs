using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleNetCoreWebApi.Configuration
{
    public class MongoDBSettings
    {
        public static string DBConnectionString { get; set; }
        public static string DatabaseName { get; set; }
    }
}
