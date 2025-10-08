using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Interfaces;
using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Services
{
    internal class FileService : ISerializer
    {
        public void Save(Calendar calendar, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(fs, calendar);

            }
        }

        public Calendar Load(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();

                return (Calendar)bf.Deserialize(fs);

            }
        }
    }
}
