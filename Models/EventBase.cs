using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models
{
    [Serializable]
    public abstract class EventBase: ISerializable // Lớp cơ bản cho Event chi tiết hơn?
    {

        private bool daNhacnho;
        private string title;
        private DateTime start;
        private DateTime end;
        private string priority;
        private bool status;
        public Reminder Reminder { get; set; }

        private List<string> categories;
        public bool DaNhacNho { get; set; } = false;
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Type { get; set; }
        public string Priority { get; set; }
        public bool Status { get; set; }

        public List<string> Categories { get; set; }

        public EventBase() { }

        protected EventBase(SerializationInfo info, StreamingContext context)
        {
            Title = info.GetString("Title");
            Start = info.GetDateTime("Start");
            End = info.GetDateTime("End");
            Type = info.GetString("Type");
            Priority = info.GetString("Priority");
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Title", Title);
            info.AddValue("Start", Start);
            info.AddValue("End", End);
            info.AddValue("Type", Type);
            info.AddValue("Priority", Priority);
        }

        public virtual string ToString()
        {
            return $"";
        }
        public virtual string DisplayInfo()
        {
            //📅 {Title} | {Start:g} - {End:g} | Loại: {Type} | Ưu tiên: {Priority}
            return $"";
        }
    }
}