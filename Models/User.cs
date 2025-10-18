using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models
{
    public class User
    {
        private string id;
        private string username;
        private string email;
        private string password;
        private string phone;

        public string Id { get { return id; } private set { ; } }
        public string Name { get { return username; } private set { } }
        public string Email { get { return email; } private set { } }
        public string Password { get { return password; } private set { } }
        public string Phone { get { return phone; } private set { } }

        public User(string n, string p)
        {
            username = n;
            password = p;
        }

        public User(string name, string e, string pass, string ph)
        {
            username = name;
            email = e;
            password = pass;
            phone = ph;
            
        }

        public static bool IsPhoneNum (string p)
        {
            bool isValid = Regex.IsMatch(p, @"^\+?\d{9,15}$");
            if (!isValid)
            {
                return false;
            }
            return true;
        }

        public void ResetPhoneNum(string p)
        {
            phone = p;
        }

    }

    internal class UserFactory
    {
        public UserFactory() { }
        public static User Create (string username, string phonenum, string pass, string email)
        {
            
            return new User(username, email, pass, phonenum);
        }
    }
}
