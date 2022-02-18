using Chat_App_DAL;
using Chat_App_DAL.Models;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add DB context to services and configure it to use our connection string with Npgsql
builder.Services.AddDbContext<ChatAppDbContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("ChatAppDb"))
    );

builder.Services.AddMvc();

// for us in production
builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "frontend/build";
});


// ********


var app = builder.Build();


// ********



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseSpa(spa =>
//{
//    spa.Options.SourcePath = "frontend";
//    if (env.IsDevelopment())
//    {
//        spa.UseReactDevelopmentServer(npmScript: "start");
//    }
//});

app.UseHttpsRedirection();

// enable resources to accept JWT
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


// **********

app.Run();


