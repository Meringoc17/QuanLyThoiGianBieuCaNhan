using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models
{
    internal abstract class EventBase // Lớp cơ bản cho Event chi tiết hơn?
    {
        private bool daNhacnho;
        private string title;
        private DateTime start;
        private DateTime end;
        private string priority;
        private string status;
        private List<Category> categories;
        public bool DaNhacNho { get; set; } = false;
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Type { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }

    }
}
