/*



*/


namespace Library
{
    public interface IChannelAdapter
    {
        string UserInput { get; set; }

        string Answer { get; set; }

        void SendTextToMediator(string data)
        {
            
        }

        void SendTextToUser(string data)
        {
            
        }

        void EndMediator(bool finish)
        {
            
        }
    }
}