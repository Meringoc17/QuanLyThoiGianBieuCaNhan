using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;
using System;
using System.Collections.Generic;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Services
{
    public class EventSortService
    {
        // Phương thức lọc sự kiện theo loại
        public static List<EventBase> FilterByType(List<EventBase> events, string selectedType)
        {
            List<EventBase> result = new List<EventBase>();

            if (events == null)
            {
                return result;
            }

            foreach (EventBase current in events)
            {
                if (current != null && current.Type == selectedType)
                {
                    result.Add(current);
                }
            }

            return result;
        }

        // Phương thức lọc sự kiện theo ưu tiên
        public static List<EventBase> FilterByPriority(List<EventBase> events, string selectedPriority)
        {
            List<EventBase> result = new List<EventBase>();

            if (events == null)
            {
                return result;
            }

            foreach (EventBase current in events)
            {
                if (current != null && current.Priority == selectedPriority)
                {
                    result.Add(current);
                }
            }

            return result;
        }

        // Phương thức sắp xếp sự kiện theo ưu tiên
        public static List<EventBase> SortByPriority(List<EventBase> events)
        {
            List<EventBase> sortedEvents = new List<EventBase>(events);

            sortedEvents.Sort((e1, e2) =>
            {
                int priority1 = GetPriorityValue(e1.Priority);
                int priority2 = GetPriorityValue(e2.Priority);
                return priority1.CompareTo(priority2);
            });

            return sortedEvents;
        }

        // Phương thức lấy giá trị ưu tiên từ chuỗi
        private static int GetPriorityValue(string priority)
        {
            switch (priority)
            {
                case "Cao":
                    return 1;
                case "Trung bình":
                    return 2;
                case "Thấp":
                    return 3;
                default:
                    return 4; // Giá trị mặc định nếu không có ưu tiên hợp lệ
            }
        }

        // Phương thức kết hợp cả lọc theo loại và ưu tiên
        public static List<EventBase> FilterAndSort(List<EventBase> events, string selectedType, string selectedPriority)
        {
            List<EventBase> filteredEvents = new List<EventBase>(events);

            // Lọc sự kiện theo loại nếu có loại được chọn
            if (!string.IsNullOrEmpty(selectedType))
            {
                filteredEvents = FilterByType(filteredEvents, selectedType);
            }

            // Lọc sự kiện theo ưu tiên nếu có ưu tiên được chọn
            if (!string.IsNullOrEmpty(selectedPriority))
            {
                filteredEvents = FilterByPriority(filteredEvents, selectedPriority);
            }

            // Sắp xếp sự kiện theo ưu tiên (ưu tiên cao lên đầu)
            return SortByPriority(filteredEvents);
        }

    }
}

