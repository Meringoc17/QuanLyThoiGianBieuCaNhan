using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models
{
    [Serializable]
    public class RecurringEvent : EventBase, ISerializable
    {
    
        public int RepeatIntervalDays { get; set; } = -1;
        public string RepeatUnit { get; set; }
        public List<DayOfWeek> Days { get; set; }
        public DateTime? EndDate { get; set; } = null;   // nên để null thay vì MinValue
        public int? Occurrences { get; set; } = 0;
        public string DaysInVN { get; set; }

        // Phần mới: Strategy
        public IRecurrenceStrategy RecurrenceStrategy { get; set; }

        public RecurringEvent()
        {
            this.Days = new List<DayOfWeek>();
        }

        public RecurringEvent(int interval, string unit, List<DayOfWeek> days,
            DateTime endInForm, int occ, bool notified, string tt, DateTime start, DateTime end,
            string type, string prio, bool status)
        {
            this.RepeatIntervalDays = interval;
            this.RepeatUnit = unit;
            this.Days = days != null ? new List<DayOfWeek>(days) : new List<DayOfWeek>();
            this.EndDate = endInForm;
            this.Occurrences = occ;
            this.DaNhacNho = notified;
            this.Title = tt;
            this.Start = start;
            this.End = end;
            this.Type = type;
            this.Priority = prio;
            this.Status = status;
        }

        public RecurringEvent(EventBase e)
        {
            this.DaNhacNho = e.DaNhacNho;
            this.Title = e.Title;
            this.Start = e.Start;
            this.End = e.End;
            this.Type = e.Type;
            this.Priority = e.Priority;
            this.Status = e.Status;
            this.Days = new List<DayOfWeek>();
        }

        public RecurringEvent(RecurringEvent e)
        {
            this.DaNhacNho = e.DaNhacNho;
            this.Title = e.Title;
            this.Start = e.Start;
            this.End = e.End;
            this.Type = e.Type;
            this.Priority = e.Priority;

            this.RepeatIntervalDays = e.RepeatIntervalDays;
            this.RepeatUnit = e.RepeatUnit;
            this.Days = e.Days != null ? new List<DayOfWeek>(e.Days) : new List<DayOfWeek>();
            this.EndDate = e.EndDate;
            this.Occurrences = e.Occurrences;

            this.RecurrenceStrategy = e.RecurrenceStrategy;
        }

        public RecurringEvent(string tt, DateTime start, DateTime end, string type, string prio)
        {
            this.Title = tt;
            this.Start = start;
            this.End = end;
            this.Type = type;
            this.Priority = prio;
            this.Days = new List<DayOfWeek>();
        }

        // sinh lần lặp tiếp theo
        public RecurringEvent(RecurringEvent template, DateTime newStart, DateTime newEnd)
            : base()
        {
            this.Title = template.Title;
            this.Type = template.Type;
            this.Priority = template.Priority;
            this.Status = false;

            this.RepeatIntervalDays = template.RepeatIntervalDays;
            this.RepeatUnit = template.RepeatUnit;
            this.Days = template.Days != null ? new List<DayOfWeek>(template.Days) : new List<DayOfWeek>();
            this.EndDate = template.EndDate;
            this.Occurrences = template.Occurrences;

            this.Start = newStart;
            this.End = newEnd;

            this.EnableReminder = template.EnableReminder;
            if (template.Reminder != null)
            {
                this.Reminder = new Reminder(template.Reminder.BeforeStart, TimeSpan.Zero, template.Reminder.Message);
            }

            this.RecurrenceStrategy = template.RecurrenceStrategy;
        }

        // DESERIALIZE
        protected RecurringEvent(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.RepeatIntervalDays = info.GetInt32("RepeatIntervalDays");
            this.RepeatUnit = info.GetString("RepeatUnit");
            this.EndDate = (DateTime?)info.GetValue("EndDate", typeof(DateTime?));
            this.Occurrences = (int?)info.GetValue("Occurrences", typeof(int?));
            this.Days = (List<DayOfWeek>)info.GetValue("Days", typeof(List<DayOfWeek>));

            try
            {
                this.RecurrenceStrategy =
                    (IRecurrenceStrategy)info.GetValue("RecurrenceStrategy", typeof(IRecurrenceStrategy));
            }
            catch
            {
                this.RecurrenceStrategy = null;
            }
        }

        // SERIALIZE
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("RepeatIntervalDays", this.RepeatIntervalDays);
            info.AddValue("RepeatUnit", this.RepeatUnit);
            info.AddValue("EndDate", this.EndDate, typeof(DateTime?));
            info.AddValue("Occurrences", this.Occurrences, typeof(int?));
            info.AddValue("Days", this.Days, typeof(List<DayOfWeek>));
            info.AddValue("RecurrenceStrategy", this.RecurrenceStrategy, typeof(IRecurrenceStrategy));
        }

        private int ThuVN(DayOfWeek dow)
        {
            int v = (int)dow;
            if (v == 0) v = 7;
            return v;
        }

        private void SortDaysByWeek(List<DayOfWeek> list)
        {
            int i;
            int j;
            for (i = 0; i < list.Count - 1; i++)
            {
                for (j = i + 1; j < list.Count; j++)
                {
                    if (ThuVN(list[i]) > ThuVN(list[j]))
                    {
                        DayOfWeek temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }

        public override string ToString()
        {
            // nếu đã có strategy thì trả về mô tả của strategy
            if (this.RecurrenceStrategy != null)
            {
                return this.RecurrenceStrategy.Describe();
            }

            // fallback về kiểu cũ
            if (this.RepeatUnit != "Tuần")
            {
                return "Lặp lại mỗi " + this.RepeatIntervalDays + " " + this.RepeatUnit;
            }

            if (this.Days != null && this.Days.Count > 0)
            {
                this.SortDaysByWeek(this.Days);

                List<string> daysInVN = new List<string>();
                int i;
                for (i = 0; i < this.Days.Count; i++)
                {
                    daysInVN.Add(FromDOWtoDaysInVN(this.Days[i]));
                }

                this.DaysInVN = "";
                for (i = 0; i < daysInVN.Count; i++)
                {
                    this.DaysInVN += daysInVN[i];
                    if (i < daysInVN.Count - 1)
                    {
                        this.DaysInVN += ", ";
                    }
                }

                return "Lặp lại mỗi " + this.RepeatIntervalDays + " " + this.RepeatUnit +
                       "\nVào các ngày: " + this.DaysInVN;
            }

            return "Lặp lại mỗi " + this.RepeatIntervalDays + " " + this.RepeatUnit;
        }

        public static DayOfWeek DayConverter(string d)
        {
            switch (d)
            {
                case "Thứ 2":
                    return DayOfWeek.Monday;
                case "Thứ 3":
                    return DayOfWeek.Tuesday;
                case "Thứ 4":
                    return DayOfWeek.Wednesday;
                case "Thứ 5":
                    return DayOfWeek.Thursday;
                case "Thứ 6":
                    return DayOfWeek.Friday;
                case "Thứ 7":
                    return DayOfWeek.Saturday;
                case "Chủ Nhật":
                    return DayOfWeek.Sunday;
                default:
                    throw new ArgumentException("Invalid DayOfWeek !");
            }
        }

        public static string FromDOWtoDaysInVN(DayOfWeek d)
        {
            switch (d)
            {
                case DayOfWeek.Monday:
                    return "Thứ 2";
                case DayOfWeek.Tuesday:
                    return "Thứ 3";
                case DayOfWeek.Wednesday:
                    return "Thứ 4";
                case DayOfWeek.Thursday:
                    return "Thứ 5";
                case DayOfWeek.Friday:
                    return "Thứ 6";
                case DayOfWeek.Saturday:
                    return "Thứ 7";
                case DayOfWeek.Sunday:
                    return "Chủ Nhật";
                default:
                    throw new ArgumentException("Invalid day of week !");
            }
        }
    }

    public class RecurringEvtFactory
    {
        public static RecurringEvent Create(int interval, string unit, List<DayOfWeek> days,
            DateTime endInForm, int occ, bool notified, string tt, DateTime start, DateTime end,
            string type, string prio, bool status)
        {
            return new RecurringEvent(interval, unit, days, endInForm, occ, notified, tt, start, end, type, prio, status);
        }

        public static RecurringEvent Create(string tt, DateTime start, DateTime end,
            string type, string prio)
        {
            return new RecurringEvent(tt, start, end, type, prio);
        }
    }
}
