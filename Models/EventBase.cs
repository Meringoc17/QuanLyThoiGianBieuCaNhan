using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models
{
    [Serializable]
    public abstract class EventBase : ISerializable
    {
        private string title;
        private DateTime start;
        private DateTime end;
        private string type;
        private bool status;
        private bool daNhac;
        private List<string> categories;
        private Reminder reminder;
        private bool enableReminder = false;
        
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Type { get; set; }
        public string Priority { get; set; }
        public bool Status { get; set; }
        public bool DaNhacNho { get; set; }
        public List<string> Categories { get; set; }
        public Reminder Reminder { get; set; }
        public bool EnableReminder { get; set; }

        public EventBase()
        {
            Categories = new List<string>();
        }

        // Constructor dùng khi Deserialize
        protected EventBase(SerializationInfo info, StreamingContext context)
        {
            Title = info.GetString("Title");
            Start = info.GetDateTime("Start");
            End = info.GetDateTime("End");
            Type = info.GetString("Type");
            Priority = info.GetString("Priority");

            try
            {
                Status = info.GetBoolean("Status");
                DaNhacNho = info.GetBoolean("DaNhacNho");
                Categories = (List<string>)info.GetValue("Categories", typeof(List<string>));
                Reminder = (Reminder)info.GetValue("Reminder", typeof(Reminder));
            }
            catch
            {
                Categories = new List<string>();
            }
        }

        // Ghi dữ liệu vào SerializationInfo
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Title", Title);
            info.AddValue("Start", Start);
            info.AddValue("End", End);
            info.AddValue("Type", Type);
            info.AddValue("Priority", Priority);
            info.AddValue("Status", Status);
            info.AddValue("DaNhacNho", DaNhacNho);
            info.AddValue("Categories", Categories);
            info.AddValue("Reminder", Reminder);
        }

        public virtual string DisplayInfo()
        {
            return $"📅 {Title} | {Start:g} - {End:g} | Ưu tiên: {Priority}";
        }
    }
}