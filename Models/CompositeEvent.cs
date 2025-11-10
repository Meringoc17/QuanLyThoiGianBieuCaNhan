using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System;

[Serializable]
public class CompositeEvent : EventBase
{
    private List<EventBase> _events = new List<EventBase>();

    public CompositeEvent(string title, DateTime start, DateTime end)
    {
        Title = title;
        Start = start;
        End = end;
    }

    // Thêm sự kiện con vào CompositeEvent
    public void Add(EventBase eventBase)
    {
        _events.Add(eventBase);
    }

    // Xóa sự kiện con
    public void Remove(EventBase eventBase)
    {
        _events.Remove(eventBase);
    }

    // Triển khai phương thức DisplayDetails
    public override void DisplayDetails()
    {
        Console.WriteLine($"Composite Event: {Title} | {Start:g} - {End:g}");
        foreach (var ev in _events)
        {
            ev.DisplayDetails();  // Gọi phương thức của sự kiện con
        }
    }

    // Serialize để lưu trữ các sự kiện con
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);  // Gọi phương thức của lớp cơ sở
        info.AddValue("Events", _events);
    }

    // Deserialize để khôi phục các sự kiện con
    protected CompositeEvent(SerializationInfo info, StreamingContext context)
        : base(info, context) // Gọi constructor của lớp cơ sở
    {
        _events = (List<EventBase>)info.GetValue("Events", typeof(List<EventBase>));
    }
}
