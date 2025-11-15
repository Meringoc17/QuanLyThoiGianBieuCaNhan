using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Exceptions
{
    internal class CategoryException: Exception // Gắn vào các chỗ lquan đến Category
    {
        public CategoryException(string message) : base(message) { }
        public CategoryException(string message, Exception exception):
            base(message, exception)
        { }
    }
}
