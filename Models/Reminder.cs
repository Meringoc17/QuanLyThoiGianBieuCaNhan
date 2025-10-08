using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models
{
    internal class Reminder
    {
        private TimeSpan b4_start;
        private string mess;

        public TimeSpan BeforeStart { get { return b4_start;  } private set {; } }
        public string Message { get { return mess; } private set {; } }

        public Reminder(TimeSpan sp, string m)
        {
            b4_start = sp;
            mess = m;
        }

        public void Notify(EventBase ev)
        {
            Console.WriteLine($"🔔 Reminder: {Message} before {ev.Title}");
        }
    }
}
