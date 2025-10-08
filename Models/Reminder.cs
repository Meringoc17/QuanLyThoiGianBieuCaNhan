using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models
{
    [Serializable]
    public class Reminder : ISerializable
    {
        private TimeSpan b4_start;
        private string mess;

        public TimeSpan BeforeStart { get { return b4_start;  } private set {; } }
        public string Message { get { return mess; } private set {; } }

        // Constructor mặc định (bắt buộc có cho Deserialization)
        public Reminder()
        {
        }
        // Constructor khởi tạo nhanh
        public Reminder(TimeSpan beforeStart, string message)
        {
            BeforeStart = beforeStart;
            Message = message;
        }
            // ✅ Constructor đặc biệt dùng khi Deserialization
            protected Reminder(SerializationInfo info, StreamingContext context)
            {
                BeforeStart = (TimeSpan)info.GetValue("BeforeStart", typeof(TimeSpan));
                Message = info.GetString("Message");
            }

            // ✅ Hàm Serialize (ghi dữ liệu vào file)
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("BeforeStart", BeforeStart);
                info.AddValue("Message", Message);
            }

            // ✅ Phương thức thông báo
            public void Notify(EventBase ev)
            {
                Console.WriteLine($"⏰ Nhắc nhở: {Message} trước khi bắt đầu sự kiện '{ev.Title}' vào {ev.Start:g}");
            }

            // ✅ Ghi đè ToString (phục vụ hiển thị trong Console hoặc báo cáo)
            public override string ToString()
            {
                return $"[Reminder] Trước: {BeforeStart.TotalMinutes} phút - Nội dung: {Message}";
            }
        }
    }

