using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models
{
    [Serializable]
    public class User  // Lớp đối tượng người dùng
    {
        private string id;
        private string username;
        private string password;
        private string phone;

        public string Id { get { return id; } private set { ; } }
        public string Name { get { return username; } private set { } }
        public string Password { get { return password; } private set { } }
        public string Phone { get { return phone; } private set { } }

        // Constructor
        public User() { }
        public User(string n, string p)
        {
            username = n;
            password = p;
        }

        // Constructor 
        public User(string name, string pass, string ph)
        {
            username = name;
            password = pass;
            phone = ph;
            
        }

        // ktra số đth
        public static bool IsPhoneNum (string p)
        {
            bool isValid = Regex.IsMatch(p, @"^\+?\d{9,15}$");
            if (!isValid)
            {
                return false;
            }
            return true;
        }

        // đặt số đth
        public void ResetPhoneNum(string p)
        {
            phone = p;
        }

        // đặt tên ng dùng
        public void SetUsername (string username)
        {
            this.username = username; 
        }

        protected User(SerializationInfo info, StreamingContext context)
        {
            id = info.GetString("Id");
            username = info.GetString("Username");
            password = info.GetString("Password");
            phone = info.GetString("Phone");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", id);
            info.AddValue("Username", username);
            info.AddValue("Password", password); // hoặc có thể mã hóa ở đây
            info.AddValue("Phone", phone);
        }
    }

    internal class UserFactory
    {
        public static User Create (string username, string phonenum, string pass)
        {
            
            return new User(username, pass, phonenum);
        }
    }
}
