using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Infrastructure.Patterns.Strategy
{
    public interface INotificationStrategy
    {
        void Send(string message);
    }

    public class EmailNotify : INotificationStrategy
    {
        public void Send(string message)
        {
            Debug.WriteLine($"Email:{message}");
        }
    }
    public class TelegramNotify : INotificationStrategy
    {
        public void Send(string message)
        {
            Debug.WriteLine($"Telegram:{message}");
        }
    }
    
    public class NotificationService
    {
        private INotificationStrategy _strategy;

        public NotificationService(INotificationStrategy strategy)
        {
            _strategy=strategy;
        }

        public void SetStrategy(INotificationStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Notify(string message)
        {
            _strategy.Send(message);
        }

    }
}
