// how to change console app to web app:
// https://www.youtube.com/watch?v=zfIRTY1dNm8&ab_channel=TheAverageDeveloperhttps://www.youtube.com/watch?v=zfIRTY1dNm8&ab_channel=TheAverageDeveloper

// packages added:
// dotnet add package MongoDB.Driver
// dotnet add package microsoft.extensions.options
// dotnet add package Swashbuckle.AspNetCore


using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PortfolioDB.Settings;
using PortfolioDB.Services;

var builder = WebApplication.CreateBuilder(args);

// for swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// looks for all controllers and adds them to the builder for the app
builder.Services.AddControllers();

// dependency injection container
builder.Services.Configure<PortfolioDBSettings>(builder.Configuration.GetSection("PortfolioContactSettings"));

// at this point, we can now inject PortfolioContactSettings to any class that needs it
builder.Services.AddSingleton<PortfolioContactService>();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// for swagger
app.UseSwaggerUI();
app.UseSwagger(x => x.SerializeAsV2 = true);


app.Run();