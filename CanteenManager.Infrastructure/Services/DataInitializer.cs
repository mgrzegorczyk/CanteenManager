using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CanteenManager.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserService userService;
        private readonly ILogger<DataInitializer> logger;

        public DataInitializer(
            IUserService userService,
            ILogger<DataInitializer> logger
        )
        {
            this.logger = logger;
            this.userService = userService;
        }

        public async Task SeedAsync()
        {
            logger.LogTrace("Initializing data...");

            var tasks = new List<Task>();

            for (int i = 1; i < 11; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"user{i}";

                tasks.Add(userService.RegisterAsync(userId, $"{username}@mail.com", "secret", "Jonh", "Doe", "user"));
                logger.LogTrace($"Creted new user {username} with id {userId}");
            }

            await Task.WhenAll(tasks);

            logger.LogTrace("Data was initialized!");
        }
    }
}