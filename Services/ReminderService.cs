using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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
            unit = unit.Trim().ToLower();

            switch (unit)
            {
                case "phút":
                case "minute":
                case "minutes":
                    return TimeSpan.FromMinutes(span);

                case "tiếng":
                case "giờ":
                case "hour":
                case "hours":
                    return TimeSpan.FromHours(span);

                case "ngày":
                case "day":
                case "days":
                    return TimeSpan.FromDays(span);

                default:
                    return TimeSpan.Zero;
            }
        }



        public static void CheckReminders(List<EventBase> events)
        {
            // Lấy thời gian hiện tại, bỏ phần giây và mili-giây
            DateTime now = DateTime.Now;
            now = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0);

            foreach (EventBase ev in events)
            {
                if (ev.Reminder != null && !ev.DaNhacNho)
                {
                    // Tính thời gian nhắc = thời gian bắt đầu - BeforeStart
                    DateTime remindTime = ev.Start - ev.Reminder.BeforeStart;
                    remindTime = new DateTime(remindTime.Year, remindTime.Month, remindTime.Day, remindTime.Hour, remindTime.Minute, 0);

                    // So sánh theo phút thay vì giây
                    if (now == remindTime)
                    {
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
