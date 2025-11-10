using System;
using System.Runtime.Serialization;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models
{
    [Serializable]
    public class OneTimeEvent : EventBase, ISerializable
    {
        public OneTimeEvent() { }

        public OneTimeEvent(string tt, DateTime start, DateTime end,
            string type, string prio)
        {
            this.Title = tt;
            this.Start = start;
            this.End = end;
            this.Type = type;
            this.Priority = prio;
        }

        public OneTimeEvent(EventBase e)
        {
            this.Title = e.Title;
            this.Start = e.Start;
            this.End = e.End;
            this.Type = e.Type;
            this.Priority = e.Priority;
            this.Status = e.Status;
            this.DaNhacNho = e.DaNhacNho;
            this.EnableReminder = e.EnableReminder;
            this.Reminder = e.Reminder;
        }

        // BẮT BUỘC: Constructor dành cho BinaryFormatter khi deserialization
        protected OneTimeEvent(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // Nếu có thêm field riêng của OneTimeEvent thì đọc ở đây bằng info.GetValue(...)
        }

        //  BẮT BUỘC: Override hàm serialization
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            // Nếu có thêm field riêng của OneTimeEvent, thêm vào đây
        }

        public override string DisplayDetails()
        {
            return $"[One-Time Event] {Title} - {Start:g} to {End:g}";
        }

        public static OneTimeEvent Create(string tt, DateTime start, DateTime end,
            string type, string prio)
        {
            return new OneTimeEvent(tt, start, end, type, prio);
        }
    }
}
