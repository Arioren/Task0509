using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task0509
{
    internal class Threats
    {
        public string ThreatType { get; set; }
        public int Volume { get; set; }
        public int Sophistication { get; set; }
        public string Target { get; set; } = string.Empty;

        public int TargetValue
        {
            get
            {
                switch (Target)
                {
                    case "Web Server":
                    {
                        return 10;
                    }
                    case "Database":
                    {
                        return 15;
                    }
                    case "User Credentials":
                    {
                        return 20;
                    }
                    default:
                    {
                        return 5;
                    }
                }
            }
            
        }
    }
}
