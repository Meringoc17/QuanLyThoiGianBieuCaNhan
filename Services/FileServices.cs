using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Interfaces;
using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Services
{
    internal class FileService : ISerializer
    {
        /// <summary>
        /// Serialize đối tượng Schedule và ghi ra file nhị phân
        /// </summary>
        public void Save(Schedule calendar, string filePath)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, calendar);
                }
                MessageBox.Show("💾 Dữ liệu đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Deserialize dữ liệu từ file nhị phân để khôi phục Schedule
        /// </summary>
        public Schedule Load(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("⚠️ File không tồn tại. Trả về lịch trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return new Schedule();
                }

                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    return (Schedule)bf.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc dữ liệu: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Schedule();
            }
        }

        public static void DeleteScheduleFile(User u)
        {
            string scheduleFilePath = ScheduleService.GetSchedFilePath(u);

            try
            {
                if (File.Exists(scheduleFilePath))
                {
                    File.Delete(scheduleFilePath); // Xóa vĩnh viễn file
                    MessageBox.Show($"Đã xóa file lịch của {u.Name} thành công!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy file lịch để xóa!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Không thể xóa file (đang bị sử dụng): " + ex.Message,
                    "Lỗi IO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa file: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
