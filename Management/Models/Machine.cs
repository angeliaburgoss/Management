using System.ComponentModel.DataAnnotations;

namespace Management.Models
{
    public class Machine
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsOnline { get; set; }
        public string LastData { get; set; }
    }
}
