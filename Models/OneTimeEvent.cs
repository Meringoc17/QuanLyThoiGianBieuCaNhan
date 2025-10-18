using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models
{
    [Serializable]
    internal class OneTimeEvent : EventBase
    {
        public OneTimeEvent(string tt, DateTime start, DateTime end,
            string type, string prio, bool status) 
        {
            this.Title = tt;
            this.Start = start;
            this.End = end;
            this.Type = type;
            this.Priority = prio;
            this.Status = status;
        }

        public OneTimeEvent(EventBase e) 
        {
            e.Title = this.Title;
            e.Start = this.Start;   
            e.End = this.End;
            e.Type = this.Type;
            e.Priority = this.Priority;
            e.Status = this.Status;
        }


        public override string ToString()
        {
            return ($"[One-Time Event] {Title} - {Start} to {End}");
        }
    }

}
