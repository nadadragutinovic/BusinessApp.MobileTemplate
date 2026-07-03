using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessApp.Infrastructure.Configuration
{
    public class ApiConfiguration
    {
        public string BaseUrl { get; set; } = "";
        public int TimeoutSecound { get; set; } = 30;
    }
}
