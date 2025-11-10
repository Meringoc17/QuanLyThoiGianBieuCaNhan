using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Services
{
    
    [Serializable]
    public class UserList : ISerializable
    {
        public List<User> Users { get; set; } = new List<User>();

        public UserList() { }

        public void Add(User user)
        {
            Users.Add(user);
        }

        public List<User> GetAll()
        {
            return Users;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Users", Users);
        }

        protected UserList(SerializationInfo info, StreamingContext context)
        {
            Users = (List<User>)info.GetValue("Users", typeof(List<User>));
        }
    }

    [Serializable]
    internal class UserManager
    {
        private static UserList users = new UserList();

        //  Lưu file ngay trong thư mục gốc project (an toàn khi rebuild)
        private static readonly string userFilePath = Path.Combine(
            Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName,
            "users.dat"
        );

        // Tự động chạy 1 lần khi chương trình load
        static UserManager()
        {
            LoadUsersFromFile();
            Add_Admin(); // đảm bảo luôn có admin
            SaveUsersToFile();
        }

        // Ghi danh sách user xuống file
        public static void SaveUsersToFile()
        {
            try
            {
                using (FileStream fs = new FileStream(userFilePath, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, users);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lưu dữ liệu user: " + ex.Message);
            }
        }

        // Đọc lại danh sách user từ file
        public static void LoadUsersFromFile()
        {
            try
            {
                if (File.Exists(userFilePath))
                {
                    using (FileStream fs = new FileStream(userFilePath, FileMode.Open))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        users = (UserList)bf.Deserialize(fs);
                    }
                }
                else
                {
                    users.Users = new List<User>();
                }
            }
            catch (Exception ex)
            {
                users.Users = new List<User>();
                throw new Exception("⚠️ Lỗi khi load dữ liệu người dùng: " + ex.Message);
            }
        }

        //  Ghi danh sách người dùng ra file
       
        // Thêm admin mặc định
        public static void Add_Admin()
        {
            if (!IsUsernameExisted("admin"))
            {
                users.Add(new User("admin", "1234"));
                SaveUsersToFile();
            }
        }

        // Đăng ký người dùng mới
        public static bool Register(string username, string phonenum, string password)
        {
            if (IsUsernameExisted(username) || IsPhoneNumExisted(phonenum))
                return false;

            users.Add(new User(username, password, phonenum));
            SaveUsersToFile(); // 🔹 Lưu ngay
            return true;
        }

        // Đăng nhập
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

        //  Kiểm tra mật khẩu (dùng nội bộ)
        public static bool PasswordCheck(string input, string pass)
        {
            if (IsUsernameExisted(input))
                return GetSpecificUser_ByUsername(input).Password == pass;

            if (IsPhoneNumExisted(input))
                return GetSpecificUser_ByPhoneNum(input).Password == pass;

            return false;
        }

        //  Kiểm tra tồn tại username
        public static bool IsUsernameExisted(string username)
        {
            foreach (User user in users.Users)
            {
                if (user.Name.Equals(username, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        //  Kiểm tra tồn tại số điện thoại
        public static bool IsPhoneNumExisted(string phonenum)
        {
            foreach (User user in users.Users)
            {
                if (user.Phone == phonenum)
                    return true;
            }
            return false;
        }

        //  Lấy user theo username
        public static User GetSpecificUser_ByUsername(string username)
        {
            foreach (User user in users.Users)
            {
                if (user.Name.Equals(username, StringComparison.OrdinalIgnoreCase))
                    return user;
            }
            throw new Exception("Không tìm thấy người dùng!");
        }

        //  Lấy user theo số điện thoại
        public static User GetSpecificUser_ByPhoneNum(string phonenum)
        {
            foreach (User user in users.Users)
            {
                if (user.Phone == phonenum)
                    return user;
            }
            throw new Exception("Không tìm thấy người dùng!");
        }

        //  Lấy toàn bộ user (dùng cho quản trị)
        public static List<User> GetAllUsers()
        {
            return users.Users;
        }
    }
}