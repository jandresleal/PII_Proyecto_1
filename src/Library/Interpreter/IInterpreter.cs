namespace Library
{
    public interface IInterpreter
    {
        void ParseInput(string input, IMediator mediator, Database database);
    }
}