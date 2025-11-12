using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models
{
    [Serializable]
    public class Category: ISerializable
    {
        private string name;
        private string description;

        public string Name { get; set; }
        public string Description { get; set; }

        public Category() { }

        public Category(string n, string des)
        {
            this.Name = n;
            this.Description = des;
        }

        protected Category(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("Name");
            Description = info.GetString("Description");
        }

        // Ghi dữ liệu vào SerializationInfo
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Description", Description);
            info.AddValue("Name", name);
        }
    }
}
