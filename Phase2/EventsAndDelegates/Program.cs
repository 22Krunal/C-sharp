using System;

namespace EventsAndDelegates
{
    public class Program
    {
        static void Main(string[] args)
        {
            var video = new Video() { Title = "Video 1"};
            var videoEncoder = new VideoEncoder(); //publisher
            var mailService = new MailService();  //subscriber
            var messsageService = new MessageService();  // subsciber


            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.VideoEncoded += messsageService.onVideoEncoded;

            videoEncoder.Encode(video);
            Console.WriteLine("Hello World!!!");  
        }
    }
}