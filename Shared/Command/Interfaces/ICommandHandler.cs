namespace Shared.Command.Interfaces
{
    public interface ICommandHandler<T> where T: IMrVinilCommand
    {
        ICommandResult Handle(T command);
    }
}
