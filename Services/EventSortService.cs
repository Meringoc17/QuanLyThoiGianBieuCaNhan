using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

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
                if (current != null)
                {
                    foreach (Category category in current.Categories)
                    {
                        if (category.Name == selectedType)
                        {
                            result.Add(current);
                            break;
                        }
                    }
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
        public static List<EventBase> SortByPriority(List<EventBase> events, string priority)
        {
            List<EventBase> sorted = new List<EventBase>(events);

            if (priority == "Thấp đến Cao")
            {
                for (int i = 1; i < sorted.Count; i++)
                {
                    EventBase key = sorted[i];
                    int j = i - 1;

                    // So sánh priority qua giá trị numeric
                    while (j >= 0 && GetPriorityValue(sorted[j].Priority) > GetPriorityValue(key.Priority))
                    {
                        sorted[j + 1] = sorted[j];
                        j--;
                    }

                    sorted[j + 1] = key;
                }
            }
            else if (priority == "Cao đến Thấp")
            {
                for (int i = 1; i < sorted.Count; i++)
                {
                    EventBase key = sorted[i];
                    int j = i - 1;

                    // So sánh priority qua giá trị numeric
                    while (j >= 0 && GetPriorityValue(sorted[j].Priority) < GetPriorityValue(key.Priority))
                    {
                        sorted[j + 1] = sorted[j];
                        j--;
                    }

                    sorted[j + 1] = key;
                }

            }    

            return sorted;
        }


        // Phương thức lấy giá trị ưu tiên từ chuỗi
        private static int GetPriorityValue(string priority)
        {
            switch (priority)
            {
                case "Thấp":
                    return 1;
                case "Trung bình":
                    return 2;
                case "Cao":
                    return 3;
                default:
                    return 4;
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

            // Sắp xếp sự kiện theo ưu tiên (trả về ds đã sắp xếp Thấp -> Cao/Cao -> Thấp)
            return SortByPriority(filteredEvents, selectedPriority);
        }

    }
}

