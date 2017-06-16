using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePizzaWebApplication.Repositories
{
    public interface IAdminRepository
    {
        Task SeedDatabaseAsync();
        Task ClearDatabaseAsync();

    }
}
