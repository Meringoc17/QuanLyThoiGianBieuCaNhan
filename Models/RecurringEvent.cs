using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models
{
    [Serializable]
    public class RecurringEvent : EventBase
    {
        public int RepeatIntervalDays { get; set; } = -1;// Lặp lại mỗi X đơn vị
        public string RepeatUnit { get; set; }     // "Ngày", "Tuần", ...
        public List<DayOfWeek> Days { get; set; }  // Những ngày chọn trg tuần
        public DateTime? EndDate { get; set; }
        public int? Occurrences { get; set; }
      
        public RecurringEvent()
        {
            Days = new List<DayOfWeek>();
        }

        public RecurringEvent(int interval, string unit, List<DayOfWeek> days,
            DateTime endInForm, int occ, bool notified, string tt, DateTime start, DateTime end,
            string type, string prio, bool status)
        {
            this.RepeatIntervalDays = interval;
            this.RepeatUnit = unit;
            this.Days = days;
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
        }

        public RecurringEvent(RecurringEvent e)
        {
            this.DaNhacNho = e.DaNhacNho;
            this.Title = e.Title;
            this.Start = e.Start;
            this.End = e.End;
            this.Type = e.Type;
            this.Priority = e.Priority;
            this.Status = e.Status;
            this.RepeatIntervalDays = e.RepeatIntervalDays;
            this.RepeatUnit = e.RepeatUnit;
            this.Days = e.Days;
            this.EndDate = e.EndDate;
            this.Occurrences = e.Occurrences;
            this.DaNhacNho = e.DaNhacNho;
        }

        public RecurringEvent(string tt, DateTime start, DateTime end, string type, string prio, bool status)
        {
            this.Title = tt;
            this.Start = start;
            this.End = end;
            this.Type = type;
            this.Priority = prio;
            this.Status = status;
        }

        // Tiện cho việc tự Generate sk lặp lại
        public RecurringEvent(RecurringEvent template, DateTime newStart, DateTime newEnd): base()
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
            this.Reminder = template.Reminder != null ? 
                new Reminder(template.Reminder.BeforeStart, TimeSpan.Zero, template.Reminder.Message) : null;
        }

        // 🔴 BẮT BUỘC: Constructor dùng khi deserialize
        protected RecurringEvent(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            RepeatIntervalDays = info.GetInt32(nameof(RepeatIntervalDays));
            RepeatUnit = info.GetString(nameof(RepeatUnit));
            EndDate = (DateTime?)info.GetValue(nameof(EndDate), typeof(DateTime?));
            Occurrences = (int?)info.GetValue(nameof(Occurrences), typeof(int?));
            Days = (List<DayOfWeek>)info.GetValue(nameof(Days), typeof(List<DayOfWeek>));
        }

        // 🔴 BẮT BUỘC: Hàm ghi dữ liệu khi serialize
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue(nameof(RepeatIntervalDays), RepeatIntervalDays);
            info.AddValue(nameof(RepeatUnit), RepeatUnit);
            info.AddValue(nameof(EndDate), EndDate, typeof(DateTime?));
            info.AddValue(nameof(Occurrences), Occurrences, typeof(int?));
            info.AddValue(nameof(Days), Days, typeof(List<DayOfWeek>));
        }

        private int ThuVN(DayOfWeek dow)
        {
            int v = (int)dow; // Sunday = 0
            if (v == 0) v = 7; // Chủ Nhật = 7
            return v;
        }

        private void SortDaysByWeek(List<DayOfWeek> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
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
            if (RepeatUnit != "Tuần")
            {
                return $"Lặp lại mỗi {RepeatIntervalDays} {RepeatUnit}";
            }

            if (Days != null && Days.Count > 0)
            {
                SortDaysByWeek(Days);

                List<string> daysInVN = new List<string>();
                foreach (DayOfWeek d in Days)
                {
                    daysInVN.Add(FromDOWtoDaysInVN(d));
                }

                string daysChosen = "";
                for (int i = 0; i < daysInVN.Count; i++)
                {
                    daysChosen += daysInVN[i];
                    if (i < daysInVN.Count - 1)
                        daysChosen += ", ";
                }

                return $"Lặp lại mỗi {RepeatIntervalDays} {RepeatUnit}\nVào các ngày: {daysChosen}";
            }

            return $"Lặp lại mỗi {RepeatIntervalDays} {RepeatUnit}";
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
                    
                default: throw new ArgumentException("Invalid day of week !");
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
            string type, string prio, bool status)
        {
            return new RecurringEvent(tt, start, end, type, prio, status);
        }
    }



}
