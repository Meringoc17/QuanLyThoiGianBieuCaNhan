using System;
using System.Runtime.Serialization;
using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Decorators
{
    [Serializable]
    public class ReminderDecorator : EventBase
    {
        private EventBase _inner;

        // ctor bình thường: bọc 1 sự kiện có sẵn
        public ReminderDecorator(EventBase inner)
        {
            _inner = inner;
        }

<<<<<<< HEAD
        /*public override string DisplayDetails()
=======
        // ctor dùng khi deserialize
        protected ReminderDecorator(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            _inner = (EventBase)info.GetValue("InnerEvent", typeof(EventBase));
        }

        // ghi dữ liệu khi serialize
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("InnerEvent", _inner, typeof(EventBase));
        }

        // trang trí thêm phần nhắc nhở
        public override string DisplayDetails()
>>>>>>> 24e8de8642ccaf71422483f724a06905832cfaf6
        {
            string baseInfo = _inner.DisplayDetails();

            if (_inner.EnableReminder && _inner.Reminder != null)
            {
                baseInfo += "\nNhắc trước: " + _inner.Reminder.BeforeStart.ToString();
            }

            return baseInfo;
        }
        */
    }
}
