using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Interfaces;
using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Strategies;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models
{
    [Serializable]
    public class RecurringEvent : EventBase, ISerializable   // sk lặp lại
    {
    
        public int RepeatIntervalDays { get; set; } = -1;
        public string RepeatUnit { get; set; }
        public List<DayOfWeek> Days { get; set; }
        public DateTime? EndDate { get; set; } = null;   // nên để null thay vì MinValue
        public int? Occurrences { get; set; } = 0;
        public string DaysInVN { get; set; }

        // Thuộc tính Interface tự tạo sk lặp lại theo RepeatUnit: Ngày, Tuần, Tháng, Năm
        public IRecurrenceStrategy RecurrenceStrategy { get; set; }

        public RecurringEvent()  // Constructor mặc định tạo List chứa ngày trg Tuần
        {
            this.Days = new List<DayOfWeek>();
        }

        public void RecurrGenerate()  // Phthuc khởi tạo sk tùy vào lchọn lặp lại
        {
            RecurrenceStrategy.Generate(this);
        }

        public IRecurrenceStrategy GetStrategy() // Phthuc lấy lớp Strategy dựa trên Đvi thgian, gắn vào thuộc tính Evt
        {
            switch (RepeatUnit.ToLowerInvariant())
            {
                case "ngày": return new DailyRecurrenceStrategy();
                case "tuần": return new WeeklyByDaysStrategy();
                case "tháng": return new MonthlyRecurrenceStrategy();
                case "năm": return new YearlyRecurrenceStrategy();
                default: throw new NotSupportedException($"Không hỗ trợ loại lặp: {RepeatUnit}");
            }
        }

        public RecurringEvent CloneWithNewDate(DateTime newStart, DateTime newEnd)
        {
            return new RecurringEvent(this, newStart, newEnd);
        }

        // Constructor lấy từng thuộc tính
        public RecurringEvent(int interval, string unit, List<DayOfWeek> days,
            DateTime endInForm, int occ, bool notified, string tt, DateTime start,  
            DateTime end, string prio, List<Category> cates, bool status)
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
            //this.Type = type;
            this.Priority = prio;
            this.Status = status;
            this.Categories = cates;
        }

        // Constructor copy 1 sk gốc
        public RecurringEvent(EventBase e)
        {
            this.DaNhacNho = e.DaNhacNho;
            this.Title = e.Title;
            this.Start = e.Start;
            this.End = e.End;
            this.Priority = e.Priority;
            this.Status = e.Status;
            this.Days = new List<DayOfWeek>();
        }

        // Constructor copy 1 sk lặp lại 
        public RecurringEvent(RecurringEvent e)
        {
            this.DaNhacNho = e.DaNhacNho;
            this.Title = e.Title;
            this.Start = e.Start;
            this.End = e.End;
            this.Priority = e.Priority;
            this.RepeatIntervalDays = e.RepeatIntervalDays;
            this.RepeatUnit = e.RepeatUnit;
            this.Days = e.Days != null ? new List<DayOfWeek>(e.Days) : new List<DayOfWeek>();
            this.EndDate = e.EndDate;
            this.Occurrences = e.Occurrences;
            this.RecurrenceStrategy = e.RecurrenceStrategy;

            // --- COPY CATEGORIES HERE ---
            this.Categories = e.Categories != null ? new List<Category>(e.Categories) : new List<Category>();
        }

        // Constructor copy các thuộc tính gốc
        public RecurringEvent(string tt, DateTime start, DateTime end,
            List<Category> categories, string prio)
        {
            this.Title = tt;
            this.Start = start;
            this.End = end;
            this.Priority = prio;
            this.Categories = categories ?? new List<Category>();
            this.Days = new List<DayOfWeek>();
        }

        // dùng để sinh lần lặp tiếp theo cho phthuc các lớp thực thi IRecurrenceStrategy
        public RecurringEvent(RecurringEvent template, DateTime newStart, DateTime newEnd)
    : base()
        {
            this.Title = template.Title;
            //this.Type = template.Type;
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

            // --- COPY CATEGORIES HERE ---
            this.Categories = template.Categories != null ? new List<Category>(template.Categories) : new List<Category>();
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

        // Chuyển đổi từ ngày trg tuần về số
        private int ThuVN(DayOfWeek dow) 
        {
            int v = (int)dow;
            if (v == 0) v = 7;
            return v;
        } 

        // Sắp xếp lại ds ngày trg tuần đã chọn
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

        // Trả về string về chi tiết lặp lại đã chọn (dùng trên txtbox MainForm)
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

        // Chuyển đổi từ ngày trg tuần từ string sang kdl DayOfWeek
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

        // Chuyển đổi DayOW sang string tiếng Việt
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

    // Lớp Factory cho khởi tạo SK lặp lại
    public class RecurringEvtFactory
    {
        public static RecurringEvent Create(int interval, string unit, List<DayOfWeek> days,
            DateTime endInForm, int occ, bool notified,
            string tt, DateTime start, DateTime end, string prio, List<Category> categories , bool status)
        {
            return new RecurringEvent(interval, unit, days, endInForm, occ, notified,
                tt, start, end, prio, categories, status);
        }
        public static RecurringEvent Create(string tt, DateTime start, DateTime end,
            List<Category> categories, string prio)
        {
            return new RecurringEvent(tt, start, end, categories, prio);
        }
    }
}
