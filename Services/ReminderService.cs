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
        public static Reminder CreateReminder (TimeSpan t)
        {
            return new Reminder (t, TimeSpan.Zero,
                    "Chuẩn bị cho sự kiện lặp lại sắp diễn ra!");
        }

        public static TimeSpan UnitConverter(int span, string unit)
        {
            switch (unit.ToLower())
            {
                case "Phút":
                    return TimeSpan.FromMinutes(span);

                case "Tiếng":
                    return TimeSpan.FromHours(span);

                case "Ngày":
                    return TimeSpan.FromDays(span);

                default:
                    return TimeSpan.Zero;
            }
        }


        public static void CheckReminders(List<EventBase> events)
        {
            DateTime now = DateTime.Now;

            foreach (EventBase ev in events)
            {
                if (ev.Reminder != null && !ev.DaNhacNho)
                {
                    DateTime remindTime = ev.Start - ev.Reminder.BeforeStart;

                    if (now >= remindTime && !ev.DaNhacNho)
                    {
                        // Gọi event thay vì MessageBox
                        ev.Reminder.Trigger(ev);
                        ev.DaNhacNho = true;
                    }
                }
            }
        }

        public static Reminder ReminderToggle(EventBase ev, bool enable, TimeSpan t)
        {
            if (enable)
            {
                ev.EnableReminder = true;
                Reminder r = new Reminder(
                    TimeSpan.FromMinutes(1), TimeSpan.Zero,
                    "Chuẩn bị cho sự kiện lặp lại sắp diễn ra!"
                );
                return r;
            }
            else 
            {
                ev.EnableReminder = false;
            } 
            throw new NotImplementedException();
        }



    }
}
