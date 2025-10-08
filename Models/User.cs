using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models
{
    internal class User
    {
        private string id;
        private string name;
        private string email;
        private string password;
        private string phone;

        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Phone { get; private set; }

        public User(string id, string name, string email, string password, string phone)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Phone = phone;
        }

        public void ShowInfo()
        {
            
        }

    }
}
