using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabRob1.Appliances
{
    class Manufacture
    {
        public string Name { get; private set; }
        public string Country { get; private set; }

        public List<string> Types { get; private set; }

        public Manufacture() { Name = "None"; Country = "None"; Types = new List<string>() { "None" }; }
        public Manufacture(string name, string country, List<string> types)
        {
            Name = name;
            Country = country;
            Types = types;
        }

    }
}
