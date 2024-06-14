using Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Management.Services
{
    public class MachineService
    {
        private List<Machine> Machines {  get; set; }

        public event Action<Machine> MachineDataSent;

        public MachineService()
        {
            Machines = new List<Machine>
            {
                new Machine { Id = Guid.NewGuid(), Name = "Machine 1", IsOnline  = true, LastData = "Data 1" },
                new Machine { Id = Guid.NewGuid(), Name = "Machine 2", IsOnline = false, LastData = "Data 2"},
                new Machine { Id = Guid.NewGuid(), Name = "Machine 3", IsOnline = true, LastData = "Data 3"}
            };
        }

        public List<Machine> GetMachines() => Machines;

        public async Task SendDataToMachine(Guid id, string data)
        {
            var machine = Machines.FirstOrDefault(m => m.Id == id);
            if (machine != null) 
            {
                machine.LastData = data;
                MachineDataSent?.Invoke(machine);
            }
        }

        public async Task AddMachine(string name)
        {
            var newMachine = new Machine
            {
                Id = Guid.NewGuid(),
                Name = name,
                IsOnline = false,
                LastData = string.Empty
            };
            Machines.Add(newMachine);
        }

        public async Task RemoveMachine(Guid id)
        {
            var machine = Machines.FirstOrDefault(m => m.Id == id);
            if (machine != null)
            {
                Machines.Remove(machine);
            }
        }
    }
}
