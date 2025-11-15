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
    internal class ScheduleService // Lớp trữ Schedule người dùng
    {
        public static List<Schedule> Schedules { get; set; } = new List<Schedule>();
        public static User currentUser = new User();

        // Load Schedule tương ứng với ng dùng
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

        // Xóa toàn bộ thông tin trong lịch
        public static void UserScheduleWipeOut(User user)
        {
            Schedule s = ScheduleLoad(user);
            Schedule.RemoveAllEvt(s);
            Schedules.Remove(s);
        }

        // lấy địa chỉ file
        public static string GetSchedFilePath(User u)
        {
            string scheduleFilePath = Path.Combine(
             Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName,
              $"schedule_{u.Name}.dat"
            );
            return scheduleFilePath;
        }

        // lưu vào file
        public static void Save(User u, Schedule sched)
        {
            try
            {
                string scheduleFilePath = GetSchedFilePath(u);
                using (FileStream fs = new FileStream(scheduleFilePath, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, sched); // ✅ serialize đúng dữ liệu hiện tại
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu file sự kiện: " + ex.Message);
            }
        }

        // tải từ file lên
        public static BindingList<EventBase> Load(User u)
        {
            string scheduleFilePath = GetSchedFilePath(u);

            // Nếu file không tồn tại → trả list rỗng
            if (!File.Exists(scheduleFilePath))
            {
                return new BindingList<EventBase>(new List<EventBase>());
            }

            try
            {
                using (FileStream fs = new FileStream(scheduleFilePath, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    Schedule currentUser_Sched = (Schedule)bf.Deserialize(fs);

                    // 🔹 Luôn đảm bảo list không null
                    return new BindingList<EventBase>(currentUser_Sched?.Events ?? new List<EventBase>());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc file lịch: {ex.Message}", "Lỗi đọc dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // 🔹 Trả về danh sách rỗng thay vì null
                return new BindingList<EventBase>(new List<EventBase>());
            }
        }

        
    }
}



