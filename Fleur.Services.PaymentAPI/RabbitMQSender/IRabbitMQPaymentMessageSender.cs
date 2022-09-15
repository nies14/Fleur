using Fleur.Services.PaymentAPI.Messages;

namespace Fleur.Services.PaymentAPI.RabbitMQSender
{
    public interface IRabbitMQPaymentMessageSender
    {
        void SendMessage(BaseMessage baseMessage);
    }
}
