using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models
{
    [Serializable]
    public abstract class EventBase : ISerializable  // Lớp abstract sk để cho 2 lớp sk 1 lần và sk lặp lại kế thừa
    {
        private string title;
        private DateTime start;
        private DateTime end;
        //private string type;
        private bool status = false;
        private bool daNhac;
        private List<Category> categories;
        private Reminder reminder;
        private bool enableReminder = false;
  
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        //public string Type { get; set; }
        public string Priority { get; set; }
        public bool Status { get; set; }
        public bool DaNhacNho { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();
        public Reminder Reminder { get; set; }
        public bool EnableReminder { get; set; }


        public EventBase() // Constructor mặc định
        {
            Categories = new List<Category>();
        }

        // Constructor dùng khi Deserialize
        protected EventBase(SerializationInfo info, StreamingContext context)
        {
            Title = info.GetString("Title");
            Start = info.GetDateTime("Start");
            End = info.GetDateTime("End");
            //Type = info.GetString("Type");
            Priority = info.GetString("Priority");


            try
            {
                Status = info.GetBoolean("Status");
                DaNhacNho = info.GetBoolean("DaNhacNho");
                Categories = (List<Category>)info.GetValue("Categories", typeof(List<Category>));
                Reminder = (Reminder)info.GetValue("Reminder", typeof(Reminder));
            }
            catch
            {
                Categories = new List<Category>();
            }
        }

        // Ghi dữ liệu vào SerializationInfo
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Title", Title);
            info.AddValue("Start", Start);
            info.AddValue("End", End);
            //info.AddValue("Type", Type);
            info.AddValue("Priority", Priority);
            info.AddValue("Status", Status);
            info.AddValue("DaNhacNho", DaNhacNho);
            info.AddValue("Categories", Categories);
            info.AddValue("Reminder", Reminder);
        }

        //  Hàm này để decorator override
        public virtual string DisplayDetails()
        {
            string s = "Tiêu đề: " + Title;
            s += "\nBắt đầu: " + Start.ToString("dd/MM/yyyy HH:mm");
            s += "\nKết thúc: " + End.ToString("dd/MM/yyyy HH:mm");
            s += "\nHạng mục: ";

            // Duyệt qua từng Category và nối chúng thành một chuỗi
            string categoryNames = "";
            foreach (Category category in Categories)
            {
                if (categoryNames.Length > 0)
                {
                    categoryNames += ", ";  // Thêm dấu phẩy giữa các tên
                }
                categoryNames += category.Name;  // Thêm tên Category vào chuỗi
            }

            s += categoryNames;
            s += "\nƯu tiên: " + Priority;
            s += "\nTrạng thái: " + (Status ? "Hoàn thành" : "Chưa xong");
            return s;
        }

        // Thêm Hạng mục
        public void AddCategory(Category category)
        {
            // Kiểm tra xem Category đã có trong danh sách chưa
            bool categoryExists = false;
            foreach (Category c in Categories)
            {
                if (c == category)  // So sánh đối tượng Category
                {
                    categoryExists = true;
                    break;
                }
            }

            // Nếu chưa có, thêm vào danh sách
            if (!categoryExists)
            {
                Categories.Add(category);
            }
        }

        // Xóa hạng mục
        public void RemoveCategory(Category category)
        {
            // Tìm và xóa Category
            foreach (Category c in Categories)
            {
                if (c == category)
                {
                    Categories.Remove(c);
                    break;
                }
            }
        }

        // Ktra hạng mục này có trg sk chưa ?
        public bool ContainsCategory(Category category)
        {
            foreach (Category c in Categories)
            {
                if (c.Name == category.Name)
                    return true;
            }
            return false;
        }

    }
}