using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Interfaces
{
   
        public interface IRecurrenceStrategy
        {
            List<DateTime> Generate(DateTime start, DateTime? endDate, int? occurrences);
            string Describe();
        }
}

