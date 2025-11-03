using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Exceptions
{
    internal class OTEvtException: Exception
    {
        public OTEvtException(string message): base(message) { }
        public OTEvtException(string message, Exception ex): base(message, ex)
        {

        }
    }
}
