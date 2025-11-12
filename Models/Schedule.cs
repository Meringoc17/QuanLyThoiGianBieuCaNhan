using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Exceptions;
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

        public Schedule(User u) : this()
        {
            Owner = u.Phone;
        }

        // Serialize – Ghi dữ liệu vào file
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Owner", Owner);
            info.AddValue("Events", Events);
        }

        //  Deserialize – Đọc dữ liệu từ file
        protected Schedule(SerializationInfo info, StreamingContext context)
        {
            try
            {
                Owner = info.GetString("Owner");
                Events = (List<EventBase>)info.GetValue("Events", typeof(List<EventBase>));
            }
            catch
            {
                Owner = "Unknown";
                Events = new List<EventBase>();
            }
        }


        public void AddEventSched(EventBase e)
        {
            Events.Add(e);
        }

        public override string ToString()
        {
            return $"📅 Lịch của: {Owner}, Tổng sự kiện: {Events.Count}";
        }


        public void RemoveEvent(EventBase e)
        {
            try
            {
                e.Reminder = null;
                Events.Remove(e);
            }
            catch (Exception ex)
            {
                throw new EventException("Lỗi không xóa được sự kiện!", ex);
            }
        }

        public void AddEvent(EventBase e)
        {
            try
            {
                Events.Add(e);
            }
            catch (Exception ex)
            {
                throw new EventException("Lỗi không thêm được sự kiện!", ex);
            }
        }

        public static void RemoveAllEvt(Schedule s)
        {
            foreach (EventBase e in s.Events)
            {
                s.RemoveEvent(e);
            }
        }
    }
}
