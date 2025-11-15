using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Interfaces;
using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Strategies
{
    public class DailyRecurrenceStrategy : IRecurrenceStrategy // cho lựa chọn đvi theo ngày
    {
        public DailyRecurrenceStrategy() {} // constructor để khởi tạo đối tượng gán vào thuộc tính của Event

        // Tính số ngày để trả lại list sk
        public List<RecurringEvent> Generate(RecurringEvent e)
        {
            List<RecurringEvent> list = new List<RecurringEvent>();
            if (e == null) return list;

            int interval = e.RepeatIntervalDays > 0 ? e.RepeatIntervalDays : 1;
            DateTime start = e.Start;
            DateTime end = e.End;

            // ✅ Xác định hạn dừng
            DateTime stopDate = (e.EndDate.HasValue && e.EndDate.Value != DateTime.MinValue)
                ? e.EndDate.Value
                : e.Start.AddDays(interval * 10);

            // ✅ Nếu Occurrences null hoặc <= 0 → coi như vô hạn, chỉ phụ thuộc stopDate
            int occurrences = (e.Occurrences.HasValue && e.Occurrences.Value > 0)
                ? e.Occurrences.Value
                : int.MaxValue;

            int count = 0;

            Debug.WriteLine($"[DailyRecurrence] Start={start}, StopDate={stopDate}, Occurrences={occurrences}, Interval={interval}");

            while (start <= stopDate && count < occurrences)
            {
                RecurringEvent clone = new RecurringEvent(e)
                {
                    Start = start,
                    End = end
                };
                list.Add(clone);

                start = start.AddDays(interval);
                end = end.AddDays(interval);
                count++;
            }

            Debug.WriteLine($"[DailyRecurrence] ✅ Generated {list.Count} recurring events.");
            return list;
        }

        public string Describe()
        {
            return "Lặp lại mỗi X ngày";
        }

    }
}
