using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Exceptions;
using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Services
{
    [Serializable]
    internal class CategoryManager: ISerializable
    {
        public static List<Category> AvailableCategories = new List<Category>();

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("AvailableCategories", AvailableCategories);
        }

        //  Deserialize – Đọc dữ liệu từ file
        protected CategoryManager(SerializationInfo info, StreamingContext context)
        {
            try
            {
                AvailableCategories = (List<Category>)info.GetValue("AvailableCategories", typeof(List<Category>));
            }
            catch
            {
                AvailableCategories = new List<Category>();
            }
        }

        // =============================================================================================================

        public void AddToAvailList(Category category) 
        {
            if (!AvailableCategories.Contains(category))
            {
                AvailableCategories.Add(category);
            }
            else
            {
                MessageBox.Show("Hạng mục này đã tồn tại!");
            }    
        }

        public static Category FindMatchToString(string c)
        {
            try
            {
                foreach (Category category in AvailableCategories)
                {
                    if (c == category.Name) return category;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hạng mục này chưa tồn tại!", "Không có hạng mục", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new CategoryException("Không tìm được hạng mục");
            }
            return null;
        }
    }
}
