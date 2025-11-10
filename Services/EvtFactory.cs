using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Services
{
    internal class EvtFactory
    {
        public static EventBase Create(string tt, DateTime start, DateTime end,
            string type, string prio, bool status, bool repeat)
        {
            OneTimeEvent o = new OneTimeEvent();
            RecurringEvent r = new RecurringEvent();
            if (repeat)
            {
                return r = RecurringEvtFactory.Create(tt, start, end, type, prio, status);
            }
            else
            {
                return o = OneTimeEvent.Create(tt, start, end, type, prio, status);
            }
        }
    }
}
