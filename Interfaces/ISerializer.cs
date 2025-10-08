using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Interfaces
{
    internal interface ISerializer
    {
        void Save(Calendar calendar, string filePath);
        Calendar Load(string filePath);
    }
}
