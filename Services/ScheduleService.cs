using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Services
{
    internal class ScheduleService
    {
        public void Save(Calendar calendar, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Calendar));
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fs, calendar);
            }
        }

        public Calendar Load(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Calendar));
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                return (Calendar)serializer.Deserialize(fs);
            }
        }
    }
}
