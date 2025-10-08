using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models
{
    [Serializable]
    internal class RecurringEvent : EventBase
    {
        public int RepeatIntervalDays { get; set; }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Recurring Event] {Title} repeats every {RepeatIntervalDays} days.");
        }
    }

}
