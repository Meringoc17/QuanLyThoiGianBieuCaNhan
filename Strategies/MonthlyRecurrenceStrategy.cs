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
    internal class MonthlyRecurrenceStrategy: IRecurrenceStrategy // cho lựa chọn đvi theo tháng
    {
        public MonthlyRecurrenceStrategy() { }

        // Tính số tháng để trả lại list sk
        public List<RecurringEvent> Generate(RecurringEvent e)
        {
            List<RecurringEvent> result = new List<RecurringEvent>();
            if (e == null) return result;

            DateTime start = e.Start;
            DateTime end = e.End;
            int count = 0;

            // Xác định số lần tối đa
            int occurrences = (e.Occurrences.HasValue && e.Occurrences.Value > 0)
                ? e.Occurrences.Value
                : int.MaxValue;

            // Xác định ngày dừng
            DateTime stopDate = (e.EndDate != DateTime.MinValue)
                ? e.EndDate.Value
                : e.Start.AddMonths((e.RepeatIntervalDays > 0 ? e.RepeatIntervalDays : 1) * 3); // mặc định 12 tháng

            while (start <= stopDate && count < occurrences)
            {
                result.Add(e.CloneWithNewDate(start, end));
                count++;

                // Cộng tháng
                int interval = e.RepeatIntervalDays > 0 ? e.RepeatIntervalDays : 1;
                start = start.AddMonths(interval);
                end = end.AddMonths(interval);
            }

            return result;
        }

        public string Describe()
        {
            return "Lặp lại hàng tháng";
        }
    }
}
