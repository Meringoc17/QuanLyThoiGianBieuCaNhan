using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Exceptions;
using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Services;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models
{
    [Serializable]
    public class Schedule : ISerializable  // Lớp đối tượng chứa list Event  
    {
        public string Owner { get; set; }
        public List<EventBase> Events { get; set; }

        // Constructor
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

        // trả về string
        public override string ToString()
        {
            return $"📅 Lịch của: {Owner}, Tổng sự kiện: {Events.Count}";
        }

        // xóa sk
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

        // thêm sk
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

        // gỡ hết sk khỏi lịch
        public static void RemoveAllEvt(Schedule s)
        {
            foreach (EventBase e in s.Events)
            {
                e.Categories.Clear();
                e.Reminder = null;
                s.RemoveEvent(e);
            }
        }
        
        // đếm sk cùng hạng mục có trong lịch
        public List<string> CategoryUsageCount()
        {
            List<string> list = new List<string>();
            foreach (Category category in CategoryManager.AvailableCategories)
            {
                int count = 0;

                foreach (EventBase ev in Events)
                {
                    if (ev.ContainsCategory(category))
                        count++;
                }
                list.Add($"Hạng mục {category.Name} có {count} sự kiện");
            }
            return list;
        }

    }
}
