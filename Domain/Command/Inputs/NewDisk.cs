using Domain.Entities;
using Shared.Command;
using Shared.Command.Interfaces;

namespace Domain.Command.Inputs
{
    public class NewDisk : IMrVinilCommand
    {
        public NewDisk(Disk disk)
        {
            Disk =  disk;
        }
        public Disk  Disk { get; set; }
    }
}
