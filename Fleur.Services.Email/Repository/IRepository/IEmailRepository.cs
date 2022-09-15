using Fleur.Services.Email.Messages;

namespace Fleur.Services.Email.Repository.IRepository
{
    public interface IEmailRepository
    {
        Task SendAndLogEmail(UpdatePaymentResultMessage message);
    }
}
