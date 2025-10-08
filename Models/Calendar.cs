using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models
{
    internal class Calendar
    {

        public string Owner { get; set; }
        public List<EventBase> Events { get; set; } = new List<EventBase>();
        public void AddEvent(EventBase ev)
        {
            Events.Add(ev);
        }

    }
}
