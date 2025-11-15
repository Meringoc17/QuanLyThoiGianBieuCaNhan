using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Exceptions
{
    internal class DataFileException : Exception // Lquan đến việc lưu file
    {
        public DataFileException(string message): base(message) { }
        public DataFileException(string message, Exception exception):
            base(message, exception) { }
    }
}
