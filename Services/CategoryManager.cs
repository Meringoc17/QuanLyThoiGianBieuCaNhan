using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Exceptions;
using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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

        public static void AddToAvailList(Category category) 
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

        public static void AddNewCateToList(string n, string des)
        {
            AddToAvailList(CategoryFactory.Create(n, des));
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

        public static string GetCtgrFilePath(User u)
        {
            string ctgrFilePath = Path.Combine(
             Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName,
              $"ListCategoryof_{u.Name}.dat"
            );
            return ctgrFilePath;
        }

        public static void Save(User u)
        {
            try
            {
                string ctgrFilePath = GetCtgrFilePath(u);
                using (FileStream fs = new FileStream(ctgrFilePath, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, AvailableCategories); // ✅ serialize đúng dữ liệu hiện tại
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu file sự kiện: " + ex.Message);
            }
        }

        public static List<Category> Load(User u)
        {
            string ctgrFilePath = GetCtgrFilePath(u);

            if (!File.Exists(ctgrFilePath))
            {
                AvailableCategories = new List<Category>();
                return AvailableCategories;
            }
            try
            {
                using (FileStream fs = new FileStream(ctgrFilePath, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    AvailableCategories = (List<Category>)bf.Deserialize(fs);

                    // 🔹 Đảm bảo không null
                    if (AvailableCategories == null)
                        AvailableCategories = new List<Category>();

                    return AvailableCategories;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc file danh mục: {ex.Message}",
                    "Lỗi đọc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);

                AvailableCategories = new List<Category>();
                return AvailableCategories;
            }
        }
    }
}
