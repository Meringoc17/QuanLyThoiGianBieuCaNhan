using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models
{
    [Serializable]
    public class Reminder : ISerializable
    {
        public delegate void ReminderTriggeredHandler(Reminder sender, EventBase ev);
        public event ReminderTriggeredHandler OnReminderTriggered;

        //=========================================================================

        private TimeSpan b4_start;
        private TimeSpan atTime;
        private string mess;

        public TimeSpan BeforeStart { get { return b4_start; } private set { b4_start = value; } }
        public TimeSpan AtTime { get { return atTime; } private set {; } }

        public string Message { get { return mess; } private set {; } }
        // Constructor mặc định (bắt buộc có cho Deserialization)
        public Reminder()
        {
        }

        // Constructor khởi tạo nhanh
        public Reminder(TimeSpan beforeStart, TimeSpan atTime, string mess)
        {
            BeforeStart = beforeStart;
            AtTime = atTime;
            this.mess = mess;
        }

        //  Constructor đặc biệt dùng khi Deserialization
        protected Reminder(SerializationInfo info, StreamingContext context)
        {
            BeforeStart = (TimeSpan)info.GetValue("BeforeStart", typeof(TimeSpan));
            AtTime = (TimeSpan)info.GetValue("AtTime", typeof(TimeSpan));
            Message = info.GetString("Message");
        }

        //  Hàm Serialize (ghi dữ liệu vào file)
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("BeforeStart", BeforeStart);
            info.AddValue("AtTime", AtTime);
            info.AddValue("Message", Message);
        }
        
        // Phương thức thông báo
        public string Notify(EventBase ev)
        {
            return ($"⏰ Nhắc nhở: {AtTime} trước khi bắt đầu sự kiện '{ev.Title}' vào {ev.Start:g}");
        }

        //  Ghi đè ToString (phục vụ hiển thị trong Console hoặc báo cáo)
        public override string ToString()
        {
            return $"[Reminder] Trước: {BeforeStart.TotalMinutes} phút";
        }

        public void Trigger(EventBase ev)
        {
            OnReminderTriggered?.Invoke(this, ev);
        }

        public void SetTimeb4Start(TimeSpan t)
        {
            b4_start = t;
        }


    }
}