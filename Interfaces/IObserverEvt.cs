using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Interfaces
{
    public interface IObserverEvt<EventBase>
    {
        void OnNext(EventBase value);     // Gửi dữ liệu mới
        void OnError(Exception e); // Báo lỗi (nếu có)
        void OnCompleted();        // Hoàn tất luồng thông báo
    }

    public interface IObservable<EventBase>
    {
        IDisposable Subscribe(IObserverEvt<EventBase> observer);
    }
}
