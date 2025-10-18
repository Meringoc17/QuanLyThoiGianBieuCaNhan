using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Services
{
    internal class ScheduleService
    {
        public static List<Schedule> Schedules { get; set; } = new List<Schedule>();


        public static Schedule ScheduleLoad(User user)
        {
            // Duyệt toàn bộ danh sách hiện có để tìm Schedule trùng Owner
            foreach (Schedule schedule in Schedules)
            {
                if (schedule.Owner == user.Phone || schedule.Owner == user.Name)
                {
                    return schedule; // Trả về nếu tìm thấy
                }
            }

            // Nếu chưa có, tạo mới
            Schedule newSched = new Schedule();
            newSched.Owner = user.Phone; // hoặc user.Username, tùy bạn chọn làm định danh
            newSched.Events = new List<EventBase>();

            Schedules.Add(newSched);
            return newSched;
        }
    }
}



