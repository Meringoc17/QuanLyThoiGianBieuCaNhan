using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Services
{
    internal class ScheduleService
    {
        public static List<Schedule> Schedules { get; set; } = new List<Schedule>();
        public static User currentUser = new User();

        private static readonly string scheduleFilePath = Path.Combine(
             Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName,
              $"schedule_{currentUser.Name}.dat");

        public static Schedule ScheduleLoad(User user)
        {
            currentUser = user;
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

        public static void Save (Schedule s)
        {
            
            try
            {
                using (FileStream fs = new FileStream(scheduleFilePath, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, s);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu file sự kiện: " + ex.Message);
            }
        }

        public static void Load(Schedule currentUser_Sched, BindingList<EventBase> allEvents)
        {
            if (File.Exists(scheduleFilePath))
            {
                try
                {
                    using (FileStream fs = new FileStream(scheduleFilePath, FileMode.Open))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        currentUser_Sched = (Schedule)bf.Deserialize(fs);
                    }
                    allEvents = new BindingList<EventBase>(currentUser_Sched.Events);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi đọc file lịch: {ex.Message}");
                    allEvents = new BindingList<EventBase>(new List<EventBase>());
                }
            }
        }
    }
}



