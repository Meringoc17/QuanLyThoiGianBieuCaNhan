using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Services
{
    internal class UserManager
    {
        private static List<User> users = new List<User>();

        // 🧩 Đường dẫn file lưu user trong AppData (không bao giờ bị xoá khi rebuild)
        private static readonly string userFilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "QuanLyThoiGianBieuCaNhan",
            "users.xml"
        );

        // ✅ Constructor tĩnh: chạy 1 lần duy nhất khi class được gọi
        static UserManager()
        {
            string folder = Path.GetDirectoryName(userFilePath);
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
        }

        // ✅ Tải người dùng từ file khi khởi động chương trình
        public static void LoadUsersFromFile()
        {
            try
            {
                if (File.Exists(userFilePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
                    using (FileStream fs = new FileStream(userFilePath, FileMode.Open))
                    {
                        users = (List<User>)serializer.Deserialize(fs);
                    }
                }
                else
                {
                    users = new List<User>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("⚠️ Lỗi khi đọc dữ liệu người dùng: " + ex.Message);
                users = new List<User>();
            }
        }

        // ✅ Lưu danh sách user xuống file
        public static void SaveUsersToFile()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
                using (FileStream fs = new FileStream(userFilePath, FileMode.Create))
                {
                    serializer.Serialize(fs, users);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("⚠️ Lỗi khi lưu dữ liệu người dùng: " + ex.Message);
            }
        }

        // ✅ Thêm admin mặc định nếu chưa có
        public static void Add_Admin()
        {
            if (!IsUsernameExisted("admin"))
                users.Add(new User("admin", "1234"));
        }

        // ✅ Đăng ký người dùng mới
        public static bool Register(string username, string phonenum, string password)
        {
            if (IsUsernameExisted(username) || IsPhoneNumExisted(phonenum))
                return false; // Đã tồn tại

            users.Add(new User(username, password, phonenum));

            // Lưu ngay xuống file để giữ lại dữ liệu sau khi tắt chương trình
            SaveUsersToFile();
            return true;
        }

        // ✅ Đăng nhập
        public static User Login(string input, string password)
        {
            User user = null;

            if (IsUsernameExisted(input))
                user = GetSpecificUser_ByUsername(input);
            else if (IsPhoneNumExisted(input))
                user = GetSpecificUser_ByPhoneNum(input);
            else
                throw new Exception("Không tìm thấy người dùng!");

            if (user.Password != password)
                throw new Exception("Sai mật khẩu!");

            return user;
        }

        // ✅ Kiểm tra mật khẩu (dùng nội bộ)
        public static bool PasswordCheck(string input, string pass)
        {
            if (IsUsernameExisted(input))
                return GetSpecificUser_ByUsername(input).Password == pass;

            if (IsPhoneNumExisted(input))
                return GetSpecificUser_ByPhoneNum(input).Password == pass;

            return false;
        }

        // ✅ Kiểm tra tồn tại username
        public static bool IsUsernameExisted(string username)
        {
            foreach (User user in users)
            {
                if (user.Name.Equals(username, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        // ✅ Kiểm tra tồn tại số điện thoại
        public static bool IsPhoneNumExisted(string phonenum)
        {
            foreach (User user in users)
            {
                if (user.Phone == phonenum)
                    return true;
            }
            return false;
        }

        // ✅ Lấy user theo username
        public static User GetSpecificUser_ByUsername(string username)
        {
            foreach (User user in users)
            {
                if (user.Name.Equals(username, StringComparison.OrdinalIgnoreCase))
                    return user;
            }
            throw new Exception("Không tìm thấy người dùng!");
        }

        // ✅ Lấy user theo số điện thoại
        public static User GetSpecificUser_ByPhoneNum(string phonenum)
        {
            foreach (User user in users)
            {
                if (user.Phone == phonenum)
                    return user;
            }
            throw new Exception("Không tìm thấy người dùng!");
        }

        // ✅ Lấy toàn bộ user (dùng cho quản trị)
        public static List<User> GetAllUsers()
        {
            return users;
        }
    }
}
