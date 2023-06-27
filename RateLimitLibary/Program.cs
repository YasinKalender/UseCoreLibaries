using AspNetCoreRateLimit;
using Microsoft.AspNetCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddOptions(); //Appsetting kýsýmdaki ayarlarýný okumak için ekledik..
builder.Services.AddMemoryCache(); //Limit durum bilgilerini cache de tutar..
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.Configure<IpRateLimitPolicies>(builder.Configuration.GetSection("IpRateLimitPolicies"));
builder.Services.AddInMemoryRateLimiting();
//builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
//builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();


//Client Rate Limit Configuration

//builder.Services.AddOptions();
//builder.Services.AddMemoryCache();
//builder.Services.Configure<ClientRateLimitOptions>(builder.Configuration.GetSection("ClientRateLimiting"));
//builder.Services.Configure<ClientRateLimitPolicies>(builder.Configuration.GetSection("ClientRateLimitPolicies"));
//builder.Services.AddInMemoryRateLimiting();
//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseIpRateLimiting();
//app.UseClientRateLimiting();

IIpPolicyStore IpPolicy = app.Services.GetRequiredService<IIpPolicyStore>();
await IpPolicy.SeedAsync();

app.UseAuthorization();

app.MapControllers();

app.Run();
