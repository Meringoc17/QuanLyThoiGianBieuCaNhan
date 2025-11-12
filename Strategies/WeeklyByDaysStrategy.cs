using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Strategies
{
    [Serializable]
    public class WeeklyByDaysStrategy : IRecurrenceStrategy, ISerializable
    {
        private int _intervalWeeks;
        private List<DayOfWeek> _days;

        public WeeklyByDaysStrategy(int intervalWeeks, List<DayOfWeek> days)
        {
            if (intervalWeeks <= 0)
            {
                _intervalWeeks = 1;
            }
            else
            {
                _intervalWeeks = intervalWeeks;
            }

            if (days == null)
            {
                _days = new List<DayOfWeek>();
            }
            else
            {
                _days = days;
            }
        }

        // ctor dùng khi deserialize
        protected WeeklyByDaysStrategy(SerializationInfo info, StreamingContext context)
        {
            _intervalWeeks = info.GetInt32("IntervalWeeks");
            _days = (List<DayOfWeek>)info.GetValue("Days", typeof(List<DayOfWeek>));
        }

        public List<DateTime> Generate(DateTime start, DateTime? endDate, int? occurrences)
        {
            List<DateTime> result = new List<DateTime>();
            int count = 0;

            List<DayOfWeek> sortedDays = new List<DayOfWeek>();
            int i;
            for (i = 0; i < _days.Count; i++)
            {
                sortedDays.Add(_days[i]);
            }
            sortedDays.Sort();

            DateTime weekStart = start.Date;

            // nếu không có endDate và không có occurrences thì dừng sau 52 tuần để tránh loop vô hạn
            int safeWeek = 0;
            int safeWeekLimit = 52;

            while (true)
            {
                for (i = 0; i < sortedDays.Count; i++)
                {
                    DayOfWeek d = sortedDays[i];
                    DateTime candidate = GetDateOfWeekday(weekStart, d, start);

                    if (candidate < start)
                    {
                        continue;
                    }

                    result.Add(candidate);
                    count++;

                    if (occurrences.HasValue && count >= occurrences.Value)
                    {
                        return result;
                    }

                    if (endDate.HasValue && candidate > endDate.Value)
                    {
                        return result;
                    }
                }

                weekStart = weekStart.AddDays(7 * _intervalWeeks);
                safeWeek++;
                if (!endDate.HasValue && !occurrences.HasValue && safeWeek >= safeWeekLimit)
                {
                    break;
                }
            }

            return result;
        }

        private DateTime GetDateOfWeekday(DateTime weekStart, DayOfWeek target, DateTime start)
        {
            int diff = (int)target - (int)weekStart.DayOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }

            DateTime day = weekStart.AddDays(diff);
            day = day.Add(start.TimeOfDay);
            return day;
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

        // serialize
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("IntervalWeeks", _intervalWeeks);
            info.AddValue("Days", _days);
        }
    }
}
