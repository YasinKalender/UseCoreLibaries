using Hangfire.UI.Models;

namespace Hangfire.UI.HangfireJobs
{
    public static class RecurringJobs //Tekrarlanar işler için kullanılan job türüdür..
    {

        public static void Recurring()
        {
            Hangfire.RecurringJob.AddOrUpdate("reccuring", () => SendMessageJobs.SendMessage(), "1 * * * *");
            Hangfire.RecurringJob.AddOrUpdate<SayHello>("reccuring1", i => i.Process(), "1 * * * *");

        }
    }
}
