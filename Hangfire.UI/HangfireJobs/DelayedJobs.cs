using Hangfire.UI.Models;

namespace Hangfire.UI.HangfireJobs
{
    public static class DelayedJobs //Belli bir zaman ayarlanan ve sadece bir kere çalışan jop tipidir..
    {
        public static void SimpleDelayedJob()
        {
            Hangfire.BackgroundJob.Schedule(() => SendMessageJobs.SendMessage(), TimeSpan.FromSeconds(30));
            Hangfire.BackgroundJob.Schedule<SayHello>(i => i.Process(), TimeSpan.FromSeconds(30));
        }

    }
}
