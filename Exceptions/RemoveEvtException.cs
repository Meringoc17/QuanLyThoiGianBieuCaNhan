using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Exceptions
{
    internal class RemoveEvtException: Exception // Ngoại lệ xóa sk
    {
        public RemoveEvtException(string message): base(message) { }
        public RemoveEvtException(string message, Exception innerException): base(message, innerException){}
    }
}
