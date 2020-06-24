namespace Library
{
    public interface IHandler
    {
        IHandler Next { set; }

        void Handle(InterpreterMessage m);
    }
}