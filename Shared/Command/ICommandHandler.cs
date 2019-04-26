namespace Shared.Command
{
    public interface ICommandHandler<T> where T: IMrVinilCommand
    {
        ICommandResult Handle(T command);
    }
}
