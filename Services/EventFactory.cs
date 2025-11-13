using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Services
{
    internal class EventFactory
    {
        public static EventBase Create(string tt, DateTime start, DateTime end,
            List<Category> categories, string prio, bool repeat)
        {
            OneTimeEvent o = new OneTimeEvent();
            RecurringEvent r = new RecurringEvent();

            if (repeat)
            {
                return r = RecurringEvtFactory.Create(tt, start, end, categories, prio);
            }
            else
            {
                return o = OneTimeEvtFactory.Create(tt, start, end, categories, prio);
            }
        }
    }
}
