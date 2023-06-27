using Hangfire.UI.Models;

namespace Hangfire.UI.HangfireJobs
{
    public static class FireAndForgetJobs //Bir kere ve hemen çalışa job tipidir..İş tanımlanır ve hemen ardından tetiklenir ve biter..
    {
        public static void SimpleJobFireAndForget()
        {
            Hangfire.BackgroundJob.Enqueue(() => SendMessageJobs.SendMessage());
            Hangfire.BackgroundJob.Enqueue<SayHello>(i => i.Process());
        }
    }
}
