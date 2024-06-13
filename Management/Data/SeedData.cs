using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Management.Data;
using Management.Models;

namespace Management.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MachineContext(
                serviceProvider.GetRequiredService<DbContextOptions<MachineContext>>()))
            {
                if (context.Machines.Any())
                {
                    return;
                }

                context.Machines.AddRange(
                    new Machine
                    {
                        Id = Guid.NewGuid(),
                        Name = "Machine 1",
                        IsOnline = true,
                        LastData = "Initial data 1"
                    },

                    new Machine
                    {
                        Id = Guid.NewGuid(),
                        Name = "Machine 2",
                        IsOnline = false,
                        LastData = "Initial data 2"
                    },

                    new Machine
                    {
                        Id = Guid.NewGuid(),
                        Name = "Machine 3",
                        IsOnline = true,
                        LastData = "Initial data 3"
                    }

                 );

                context.SaveChanges();
            }
        }
    }
}
