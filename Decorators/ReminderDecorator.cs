using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Decorators
{
    public class ReminderDecorator : EventBase
    {
        private EventBase _eventBase;

        public ReminderDecorator(EventBase eventBase)
        {
            _eventBase = eventBase;
        }

        public override string DisplayDetails()
        {
            _eventBase.DisplayDetails();  // Gọi DisplayDetails của sự kiện gốc
            return $"Reminder: {Reminder.Notify(_eventBase)}";
        }
    }

}
