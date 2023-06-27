namespace Hangfire.UI.HangfireJobs
{
    [AutomaticRetry(Attempts = 7)] //Hangfire hata aldığı zaman 10 kez tekrar deneyip hataya düşer.Metot seviyesinde değiştirmek isterseniz, metodumuza aşağıdaki özelliği ekleyebilirsiniz.
    public static class ContinuationsJobs
    {
        public static void Continuations()
        {
            var parentJobId = Hangfire.BackgroundJob.Schedule(() => Console.WriteLine("1. Job"), TimeSpan.FromSeconds(10));
            Hangfire.BackgroundJob.ContinueJobWith(parentJobId, () => Console.WriteLine("Continuations Job"));
        }
    }
}
