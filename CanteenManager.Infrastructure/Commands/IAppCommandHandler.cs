using System.Threading.Tasks;

namespace CanteenManager.Infrastructure.Commands
{
    public interface IAppCommandHandler<T> where T : IAppCommand
    {
        Task HandleAsync(T command);
    }
}