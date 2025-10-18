using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Services
{
    internal class EventManager
    {
        public static EventBase EvtFactory(EventBase e, bool repeat)
        {
            if (repeat)
            {
                return new RecurringEvent(e);
            }
            else
            {
                return new OneTimeEvent(e);
            }
        }
                
    }
}
