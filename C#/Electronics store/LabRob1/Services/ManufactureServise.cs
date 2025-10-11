using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace LabRob1.Services
{
    public class ManufactureService
    {
        List<ManufactureApp> manufactures;

        public ManufactureService(string path)
        {
            string jsonData = File.ReadAllText(path);
            manufactures = JsonConvert.DeserializeObject<List<ManufactureApp>>(jsonData);
        }

        public ManufactureApp GetManufacture(string name)
        {
            foreach( ManufactureApp manufactureApp in manufactures)
                if(manufactureApp.Name ==name)
                    return manufactureApp;

            throw null;
        } 

        public List<string> GetManufactures(string type, string field)
        {
            List<string> man = new List<string>();

            foreach (ManufactureApp item in manufactures)
                if (item.Types.Contains(type))
                {
                    if (field == "Name")
                         man.Add(item.Name);
                    else if (field == "Country" )
                        man.Add(item.Country); 
                }
                return man.Distinct().ToList();   
            
        }

        public List<string> GetAllManufactures(string field)
        {
            List<string> man = new List<string>();

            foreach (ManufactureApp item in manufactures)
            {
                if (field == "Name")
                    man.Add(item.Name);
                else if (field == "Country") 
                man.Add(item.Country);
            }
            return man.Distinct().ToList();

        }


    }
}
