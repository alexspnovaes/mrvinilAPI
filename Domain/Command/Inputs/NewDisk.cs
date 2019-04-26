using Domain.Entities;
using Shared.Command;

namespace Domain.Command
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
