using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Strategies
{
    [Serializable]
    public class DailyRecurrenceStrategy : IRecurrenceStrategy, ISerializable
    {
        private int _intervalDays;

        public DailyRecurrenceStrategy(int intervalDays)
        {
            if (intervalDays <= 0)
            {
                _intervalDays = 1;
            }
            else
            {
                _intervalDays = intervalDays;
            }
        }

        // ctor dùng khi deserialize
        protected DailyRecurrenceStrategy(SerializationInfo info, StreamingContext context)
        {
            _intervalDays = info.GetInt32("IntervalDays");
        }

        public List<DateTime> Generate(DateTime start, DateTime? endDate, int? occurrences)
        {
            List<DateTime> result = new List<DateTime>();
            DateTime current = start;
            int count = 0;
            bool stop = false;

            while (!stop)
            {
                result.Add(current);
                count++;

                if (occurrences.HasValue && count >= occurrences.Value)
                {
                    break;
                }

                current = current.AddDays(_intervalDays);

                if (endDate.HasValue && current > endDate.Value)
                {
                    stop = true;
                }
            }

            return result;
        }

        public string Describe()
        {
            return "Lặp lại mỗi " + _intervalDays + " ngày";
        }

        // serialize
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("IntervalDays", _intervalDays);
        }
    }
}
