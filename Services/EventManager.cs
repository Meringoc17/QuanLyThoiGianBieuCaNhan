using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;
using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Services
{

    internal class EventManager
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

        public static RecurringEvent RepeatwUnitCalculation(
            RecurringEvent old, List<EventBase> list)
        {
            string downcaseOldUnit = old.RepeatUnit.ToLowerInvariant();
            DateTime newStart = old.Start;
            DateTime newEnd = old.End;
            switch (downcaseOldUnit)
            {
                case "ngày":
                    newStart = old.Start.AddDays(old.RepeatIntervalDays);
                    newEnd = old.End.AddDays(old.RepeatIntervalDays);
                    break;
                case "tuần":
                    // 1) Cộng số tuần
                    newStart = old.Start.AddDays(old.RepeatIntervalDays * 7);

                    for (int i = 0; i < old.Days.Count - 1; i++)
                    {
                        for (int j = i + 1; j < old.Days.Count; j++)
                        {
                            int di = (int)old.Days[i]; if (di == 0) di = 7;
                            int dj = (int)old.Days[j]; if (dj == 0) dj = 7;

                            if (di > dj)
                            {
                                DayOfWeek tmp = old.Days[i];
                                old.Days[i] = old.Days[j];
                                old.Days[j] = tmp;
                            }
                        }
                    }

                    // 3) Dịch đến đúng day-of-week tiếp theo
                    DayOfWeek current = newStart.DayOfWeek;

                    int currIndex = (int)current;
                    if (currIndex == 0) currIndex = 7;

                    // tìm ngày kế tiếp trong danh sách old.Days
                    for (int i = 0; i < old.Days.Count; i++)
                    {
                        int di = (int)old.Days[i];
                        if (di == 0) di = 7;

                        if (di >= currIndex)
                        {
                            newStart = newStart.AddDays(di - currIndex);
                            break;
                        }

                        // nếu không có cái nào >= → nhảy sang tuần kế
                        if (i == old.Days.Count - 1)
                        {
                            int firstDay = (int)old.Days[0];
                            if (firstDay == 0) firstDay = 7;

                            newStart = newStart.AddDays((7 - currIndex) + firstDay);
                        }
                    }
                    // 4) Giữ duration cũ
                    TimeSpan t = old.End - old.Start;
                    newEnd = newStart + t;
                    break;

                case "tháng":
                    newStart = old.Start.AddMonths(old.RepeatIntervalDays);
                    newEnd = old.End.AddMonths(old.RepeatIntervalDays);
                    break;
                case "năm":
                    newStart = old.Start.AddYears(old.RepeatIntervalDays);
                    newEnd = old.End.AddYears(old.RepeatIntervalDays);
                    break;

                default:
                    break;
                    

            }

            RecurringEvent recurringEvent = new RecurringEvent(old, newStart, newEnd);
            return recurringEvent;
        }

        public static RecurringEvent rcEvt_EndGenLoop(Schedule s, RecurringEvent e)
        {
            // Nếu event cũ đã kết thúc
            if (e.End < DateTime.Now)
            {
                // Còn hạn theo ngày
                if (e.EndDate == DateTime.MinValue || e.End < e.EndDate)
                {
                    return RCEvt_AutoGenerate(s, e);
                }
                // Còn hạn theo số lần
                else if (e.Occurrences > 0)
                {
                    e.Occurrences--;
                    return RCEvt_AutoGenerate(s, e);
                }
            }

            return null; //  Không tạo mới
        }

        public static RecurringEvent RCEvt_AutoGenerate(Schedule s, RecurringEvent e)
        {
            RecurringEvent newEvt = RepeatwUnitCalculation(e, s.Events);

            // Tránh trùng event
            for (int i = 0; i < s.Events.Count; i++)
            {
                if (s.Events[i].Start == newEvt.Start && 
                    s.Events[i].End == newEvt.End && s.Events[i].Title != newEvt.Title)
                    return null;
            }

            return newEvt;
        }

        
    }
}
