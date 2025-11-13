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
    }
}
