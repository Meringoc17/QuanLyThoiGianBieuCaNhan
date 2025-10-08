using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models
{
    [Serializable]
    internal class OneTimeEvent : EventBase
    {
        public override void DisplayInfo()
        {
            Console.WriteLine($"[One-Time Event] {Title} - {Start} to {End}");
        }
    }

}
