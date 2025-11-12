using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Exceptions
{
    internal class CategoryException: Exception
    {
        public CategoryException(string message) : base(message) { }
        public CategoryException(string message, Exception exception) :
            base(message, exception)
        { }
    }
}
