using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;
using System;
using System.Collections.Generic;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Services
{
    internal class UserManager
    {
        private static List<User> users = new List<User>();

        // ✅ Chỉ gọi một lần khi chương trình khởi động
        public static void Add_Admin()
        {
            if (!IsUsernameExisted("admin"))
                users.Add(new User("admin", "1234"));
        }

        public static bool Register(string usernameOrPhone, string password)
        {
            if (IsUsernameExisted(usernameOrPhone) || IsPhoneNumExisted(usernameOrPhone))
                return false; // Đã tồn tại

            users.Add(new User(usernameOrPhone, password));
            return true;
        }

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

        // ✅ Logic kiểm tra an toàn, không ném lỗi lung tung
        public static bool PasswordCheck(string input, string pass)
        {
            if (IsUsernameExisted(input))
                return GetSpecificUser_ByUsername(input).Password == pass;

            if (IsPhoneNumExisted(input))
                return GetSpecificUser_ByPhoneNum(input).Password == pass;

            return false;
        }

        public static bool IsUsernameExisted(string username)
        {
            foreach (User user in users)
            {
                if (user.Name.Equals(username, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        public static bool IsPhoneNumExisted(string phonenum)
        {
            foreach (User user in users)
            {
                if (user.Phone == phonenum)
                    return true;
            }
            return false;
        }

        public static User GetSpecificUser_ByUsername(string username)
        {
            foreach (User user in users)
            {
                if (user.Name.Equals(username, StringComparison.OrdinalIgnoreCase))
                    return user;
            }
            throw new Exception("Không tìm thấy người dùng!");
        }

        public static User GetSpecificUser_ByPhoneNum(string phonenum)
        {
            foreach (User user in users)
            {
                if (user.Phone == phonenum)
                    return user;
            }
            throw new Exception("Không tìm thấy người dùng!");
        }

        public static List<User> GetAllUsers()
        {
            return users;
        }
    }
}
