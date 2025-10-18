using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models
{
    [Serializable]
    public class Schedule : ISerializable
    {
        public string Owner { get; set; }
        public List<EventBase> Events { get; set; }

        public Schedule()
        {
            Events = new List<EventBase>();
        }

        public Schedule(User u): this()
        {
            Owner = u.Phone;
        }

        //=================================================================================
        /// <summary>
        /// Serialization nằm ở phân khúc này.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
  
        // Constructor dùng khi Deserialize
        protected Schedule(SerializationInfo info, StreamingContext context)
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

        //==================================================================================

        public void AddEventSched(EventBase e)
        {
            Events.Add(e);
        }

        public override string ToString()
        {
            return $"📅 Lịch của: {Owner}, Tổng sự kiện: {Events.Count}";
        }
    }
    
    public class ScheduleFactory
    {
        public static Schedule Create()
        {
            return new Schedule();
        }

    }
}
