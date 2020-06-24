namespace Library
{
    public class BaseHandler : SingleInstance<BaseHandler>
    {
        public IHandler Next { get; set; }

        public virtual void Handle(Message m)
        {
            if (this.Next != null)
            {
                this.Next.Handle(m);
            }
        }
    }
}