using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models
{
    [Serializable]
    public class Calendar : ISerializable
    {
        public string Owner { get; set; }
        public List<EventBase> Events { get; set; }

        public Calendar()
        {
            Events = new List<EventBase>();
        }

        // Constructor dùng khi Deserialize
        protected Calendar(SerializationInfo info, StreamingContext context)
        {
            Owner = info.GetString("Owner");
            Events = (List<EventBase>)info.GetValue("Events", typeof(List<EventBase>));
        }

        // Hàm Serialize dữ liệu vào file
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Owner", Owner);
            info.AddValue("Events", Events);
        }

        public override string ToString()
        {
            return $"📅 Lịch của: {Owner}, Tổng sự kiện: {Events.Count}";
        }
    }
}
