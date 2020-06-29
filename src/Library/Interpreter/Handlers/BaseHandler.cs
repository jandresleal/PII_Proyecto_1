namespace Library
{
    public class BaseHandler : IHandler
    {
        public IHandler Next { get; set; }

        public virtual void Handle(InterpreterMessage m)
        {
            if (this.Next != null)
            {
                this.Next.Handle(m);
            }
        }
    }
}