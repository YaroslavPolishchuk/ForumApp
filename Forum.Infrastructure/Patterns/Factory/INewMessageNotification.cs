using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Infrastructure.Patterns.Factory
{
    public interface INewMessageNotification
    {
        void Send(string message);
    }

    public interface ITelegramNotify : INewMessageNotification
    {

    }

    public class TelegramNotify : ITelegramNotify
    {
        public void Send(string message)
        {
            throw new NotImplementedException();
        }
    }   

    public class NotificaionFactory
    {
        public static T GetNofier<T>() where T :INewMessageNotification, new()
        {
            return new T();
        }
    }
}
