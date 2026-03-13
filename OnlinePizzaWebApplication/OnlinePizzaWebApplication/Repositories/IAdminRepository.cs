using System.Threading.Tasks;

namespace OnlinePizzaWebApplication.Repositories
{
    public interface IAdminRepository
    {
        Task SeedDatabaseAsync();
        Task ClearDatabaseAsync();
    }
}
