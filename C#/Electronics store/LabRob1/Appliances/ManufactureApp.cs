using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabRob1
{
    public class ManufactureApp
    {
        public string Name { get;  set; }
        public string Country { get; set; }

        public List<string> Types { get; private set; }

        public ManufactureApp() { Name = "None"; Country = "None"; Types = new List<string>() { "None" }; }
        public ManufactureApp(string name, string country, List<string> types)
        {
            Name = name;
            Country = country;
            Types = types;
        }
        public override string ToString()
        {
            return $"Бренд:{Name}, Країна:  {Country}";
        }
    }
}
