using Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Data
{
    public class MachineContext : DbContext
    {
        public MachineContext(DbContextOptions<MachineContext> options) :base(options)
        {
        }

        public DbSet<Machine> Machines { get; set; }

    }
}
