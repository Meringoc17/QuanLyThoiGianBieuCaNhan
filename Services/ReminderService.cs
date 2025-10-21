using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Services
{
    internal class ReminderService
    {
        public static void CheckReminders(List<EventBase> events)
        {
            DateTime now = DateTime.Now;

            foreach (EventBase ev in events)
            {
                if (ev.Reminder != null && !ev.DaNhacNho)
                {
                    DateTime remindTime = ev.Start - ev.Reminder.BeforeStart;

                    if (now >= remindTime && now < ev.Start)
                    {
                        // Gọi event thay vì MessageBox
                        ev.Reminder.Trigger(ev);
                        ev.DaNhacNho = true;
                    }
                }
            }
        }

    }
}
