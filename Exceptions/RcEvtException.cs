using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Exceptions
{
    internal class RcEvtException: ApplicationException // Lquan đến sk lặp
    {
        public RcEvtException(string message): base(message) { }

        public RcEvtException(string message, Exception e): base(message, e)  { }

    }
}
