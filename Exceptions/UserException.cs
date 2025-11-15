using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Exceptions
{
    internal class UserException: Exception // Ngoại lệ người dùng
    {
        public UserException(string message): base(message) { }

        public UserException(string message, Exception exception): base(message, exception) { }
    }
}
