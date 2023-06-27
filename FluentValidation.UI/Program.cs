using FluentValidation.AspNetCore;
using FluentValidation.UI.CustomFilter;
using FluentValidation.UI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(i => i.ModelValidatorProviders.Clear()).AddFluentValidation(opt =>
{
    //opt.RegisterValidatorsFromAssemblyContaining<Program>();
    opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ValidateModelStateAttribute));
});

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddDbContext<ProjectDbContext>(opt => opt.UseSqlServer(builder.Configuration["MyConnectionString"]));

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
