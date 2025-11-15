using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Interfaces;
using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Strategies
{
    internal class YearlyRecurrenceStrategy: IRecurrenceStrategy
    {
        public YearlyRecurrenceStrategy() { }

        // Tính số năm để trả lại list sk tương ứng
        public List<RecurringEvent> Generate(RecurringEvent e)
        {
            List<RecurringEvent> result = new List<RecurringEvent>();
            if (e == null) return result;

            DateTime start = e.Start;
            DateTime end = e.End;
            int count = 0;

            // Số lần tối đa
            int occurrences = (e.Occurrences.HasValue && e.Occurrences.Value > 0)
                ? e.Occurrences.Value
                : int.MaxValue;

            // Ngày dừng mặc định nếu EndDate không có
            DateTime stopDate = (e.EndDate != DateTime.MinValue)
                ? e.EndDate.Value
                : e.Start.AddYears((e.RepeatIntervalDays > 0 ? e.RepeatIntervalDays : 1) * 10); // mặc định 10 năm

            int interval = e.RepeatIntervalDays > 0 ? e.RepeatIntervalDays : 1;

            while (start <= stopDate && count < occurrences)
            {
                result.Add(e.CloneWithNewDate(start, end));
                count++;

                start = start.AddYears(interval);
                end = end.AddYears(interval);
            }

            return result;
        }

        public string Describe()
        {
            return "Lặp lại hàng năm";
        }
    }
}
