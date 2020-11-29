using System.Threading.Tasks;

namespace CanteenManager.Infrastructure.Commands
{
    public interface IAppCommandDispatcher
    {
        Task DispatchAsync<T>(T command) where T: IAppCommand;
    }
}