using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabRob1
{
    public class ApplianceService
    {
        public void SaveToFile(string path, List<Appliances> aList)
        {
            int count = aList.Count;
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create))
                using (BinaryWriter writer = new BinaryWriter(fs))
                {
                    writer.Write(count);

                    foreach(Appliances a in aList)
                    {
                        writer.Write(a.GetType().FullName);
                        a.WriteToFile(writer);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка збереження до файлу {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Appliances> LoadFromFile(string path)
        {
            List<Appliances> aList = new List<Appliances>();

            try
            {
                using (FileStream fs = new FileStream(path,FileMode.Open))
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    int count = reader.ReadInt32();

                    for(int i = 0; i < count; i++)
                    {
                        Type type = Type.GetType(reader.ReadString());

                        Appliances a = (Appliances)Activator.CreateInstance(type);
                        
                        a.ReadFromFile(reader);

                        aList.Add(a);   
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка читання з файлу {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return aList;
        }

        
    }
}
