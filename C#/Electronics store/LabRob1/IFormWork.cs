using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabRob1
{
    public interface IFormWork
    {
        void FillDataRow(DataRow row);
        void ImagesWhenDelete(Form1 form);
    }
}
