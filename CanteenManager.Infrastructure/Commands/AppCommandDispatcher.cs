using System;
using System.Threading.Tasks;
using Autofac;

namespace CanteenManager.Infrastructure.Commands
{
    public class AppCommandDispatcher : IAppCommandDispatcher
    {
        private readonly IComponentContext componentContext;
        public AppCommandDispatcher(IComponentContext componentContext)
        {
            this.componentContext = componentContext;

        }
        public async Task DispatchAsync<T>(T command) where T : IAppCommand
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command), $"Command {typeof(T).Name} can not be null");
            }

            var handler = componentContext.Resolve<IAppCommandHandler<T>>();
            await handler.HandleAsync(command);
        }
    }
}