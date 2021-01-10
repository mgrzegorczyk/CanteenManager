using System.Threading.Tasks;

namespace CanteenManager.Infrastructure.Services
{
    public interface IDataInitializer
    {
        Task SeedAsync();
    }
}