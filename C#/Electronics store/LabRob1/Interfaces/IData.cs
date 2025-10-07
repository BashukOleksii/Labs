using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabRob1
{
    public interface IData
    {
        void WriteToFile(BinaryWriter writer);
        void ReadFromFile(BinaryReader reader);

    }
}
