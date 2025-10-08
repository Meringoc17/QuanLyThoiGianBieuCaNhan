using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;
using System;
using System.Collections.Generic;
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

        
            public void PrintSchedule(Calendar calendar)
            {
                Console.WriteLine("\n📘 LỊCH CỦA " + calendar.Owner + ":");

                if (calendar.Events == null || calendar.Events.Count == 0)
                {
                    Console.WriteLine("Không có sự kiện nào trong lịch.");
                    return;
                }

                for (int i = 0; i < calendar.Events.Count; i++)
                {
                    EventBase ev = calendar.Events[i];
                    ev.DisplayInfo();
                }
            }
        }
    }



