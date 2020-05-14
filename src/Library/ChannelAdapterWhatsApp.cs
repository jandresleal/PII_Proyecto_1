namespace Library
{
    public class ChannelAdapterWhatsApp : IChannelAdapter
    {
        public string UserInput { get; set; }

        public string Answer { get; set; }

        private bool finish;

        public void SendTextToInterpreter(string data)
        {
            
        }
        public void SendTextToUser(string data)
        {
            
        }
        public void EndMediator(bool finish)
        {
            
        }
    }
}