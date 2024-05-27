namespace EventsAndDelegates
{
    public class MessageService
    {
        public void onVideoEncoded(object source, EventArgs e)
        {
            Console.WriteLine("MessageService : Sending a text message ......");
        }
    }
}