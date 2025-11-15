using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Interfaces
{
    public interface IRecurrenceStrategy // Des. Pattern Strategy: Daily, Weekly, Monthly, Yearly
    {
        List<RecurringEvent> Generate(RecurringEvent recurringEvent);
        string Describe();
    }
}

