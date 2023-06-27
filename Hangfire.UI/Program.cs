using Hangfire;
using HangfireBasicAuthenticationFilter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHangfire(_ => _.UseSqlServerStorage(builder.Configuration.GetConnectionString("HangfireDatabase")));
builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    DashboardTitle = "Yasin Kalender",
    Authorization = new[]
    {
        new HangfireCustomBasicAuthenticationFilter
        {
            User = builder.Configuration.GetSection("HangfireSettings:UserName").Value,
            Pass = builder.Configuration.GetSection("HangfireSettings:Password").Value
        }
    }

});

GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 8 }); //Hangfire hata aldýðý zaman 10 kez tekrar deneyip hatay düþer. GlobalJobFilters hata sayýsýný belirtiyor..

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
