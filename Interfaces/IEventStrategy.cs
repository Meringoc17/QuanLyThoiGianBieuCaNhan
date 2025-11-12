using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Interfaces
{
    public interface IEventStrategy
    {
        void ProcessEvent(EventBase e);
    }

    public class IRecurringEventStrategy: IEventStrategy
    {
        public void ProcessEvent(EventBase e) 
        { 

        }
    }

    public class IOneTimeEventStrategy : IEventStrategy
    {
        public void ProcessEvent(EventBase e)
        {

        }
    }
}
