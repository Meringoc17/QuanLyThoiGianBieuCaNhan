using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Interfaces;
using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Strategies
{
    [Serializable]
    public class WeeklyByDaysStrategy : IRecurrenceStrategy
    {
        private int _intervalWeeks;
        private List<DayOfWeek> _days;

        public WeeklyByDaysStrategy() { }

        // Tính số tuần và ngày trg tuần để trả lại list sk tương ứng
        public List<RecurringEvent> Generate(RecurringEvent e)
        {
            List<RecurringEvent> result = new List<RecurringEvent>();
            if (e == null) return result;

            DateTime current = e.Start;
            int count = 0;

            // Xác định số lần tối đa
            int occurrences = (e.Occurrences.HasValue && e.Occurrences.Value > 0)
                ? e.Occurrences.Value
                : int.MaxValue;

            // Xác định ngày dừng
            DateTime stopDate = (e.EndDate != DateTime.MinValue)
                ? e.EndDate.Value
                : e.Start.AddDays((e.RepeatIntervalDays > 0 ? e.RepeatIntervalDays : 1) * 7 * 4); // mặc định 4 tuần

            // Days rỗng → mặc định ngày bắt đầu
            if (e.Days == null || e.Days.Count == 0)
                e.Days = new List<DayOfWeek> { current.DayOfWeek };

            // Sắp xếp thứ tự ngày trong tuần (Sun = 7)
            for (int i = 0; i < e.Days.Count - 1; i++)
            {
                for (int j = i + 1; j < e.Days.Count; j++)
                {
                    int di = (int)e.Days[i] == 0 ? 7 : (int)e.Days[i];
                    int dj = (int)e.Days[j] == 0 ? 7 : (int)e.Days[j];
                    if (di > dj)
                    {
                        DayOfWeek tmp = e.Days[i];
                        e.Days[i] = e.Days[j];
                        e.Days[j] = tmp;
                    }
                }
            }

            while (current <= stopDate && count < occurrences)
            {
                foreach (DayOfWeek day in e.Days)
                {
                    int diff = ((int)day - (int)current.DayOfWeek + 7) % 7;
                    DateTime next = current.AddDays(diff);

                    if (next < e.Start) continue;
                    if (next > stopDate) continue; // dùng continue chứ không break

                    DateTime nextEnd = next.Add(e.End - e.Start);
                    result.Add(e.CloneWithNewDate(next, nextEnd));
                    count++;

                    if (count >= occurrences)
                        return result;
                }

                int interval = e.RepeatIntervalDays > 0 ? e.RepeatIntervalDays : 1;
                current = current.AddDays(7 * interval);
            }

            return result;
        }

        public string Describe()
        {
            string text = "Lặp lại mỗi " + _intervalWeeks + " tuần vào: ";
            int i;
            for (i = 0; i < _days.Count; i++)
            {
                text += _days[i].ToString();
                if (i < _days.Count - 1)
                {
                    text += ", ";
                }
            }
            return text;
        }

    }
}
