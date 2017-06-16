using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlinePizzaWebApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using OnlinePizzaWebApplication.Repositories;
using Microsoft.EntityFrameworkCore;

namespace OnlinePizzaWebApplication.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(AppDbContext context, IServiceProvider serviceProvider, 
            IAdminRepository adminRepository)
        {
            context.Database.EnsureCreated();

            if (await context.Pizzas.AnyAsync())
            {
                return;
            }
            else
            {
                await adminRepository.ClearDatabaseAsync();
                await adminRepository.SeedDatabaseAsync();
            }

        }

    }
}
