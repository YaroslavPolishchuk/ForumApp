using Microsoft.Extensions.Logging;

namespace Forum.Infrastructure.Patterns.Decorator
{
    struct asdasdasd
    {
        public string Name { get; set; }

    }
    public interface IMessageService
    {
        void PostMessage(string message);
    }

    public class MessageService : IMessageService
    {
        public void PostMessage(string message)
        {
            //Conndect to db and add new row {message}
            //
        }
    }

    public class MeessageLoggerWrapper : IMessageService
    {
        private readonly IMessageService _messageService;
        private readonly ILogger<MeessageLoggerWrapper> _logger;

        public MeessageLoggerWrapper(IMessageService messageService, ILogger<MeessageLoggerWrapper> logger)
        {
            _messageService = messageService;
            _logger = logger;
        }
        public void PostMessage(string message)
        {
            _messageService.PostMessage(message);
            _logger.LogInformation(message);
        }
    }
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        IMessageService service = new MessageService();
    //        using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
    //        ILogger logger = factory.CreateLogger<MeessageLoggerWrapper>();
    //        service = new MeessageLoggerWrapper(service, logger);

    //        service.PostMessage("Hello");
    //    }
    //}
}
