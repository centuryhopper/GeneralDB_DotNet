// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
// how to change console app to web app: https://www.youtube.com/watch?v=zfIRTY1dNm8&ab_channel=TheAverageDeveloperhttps://www.youtube.com/watch?v=zfIRTY1dNm8&ab_channel=TheAverageDeveloper
// packages added:
// dotnet add package MongoDB.Driver --version 2.18.0
// dotnet add package DotNetEnv


using System;
using MongoDB.Driver;
using Models;

DotNetEnv.Env.Load();

// System.Console.WriteLine(Environment.GetEnvironmentVariable("PORT"));
// System.Console.WriteLine(Environment.GetEnvironmentVariable("MONGO_URI"));

var collectionName = "PortfolioContact";
var client = new MongoClient(Environment.GetEnvironmentVariable("MONGO_URI"));

// sanity check
// var dbs = client.ListDatabaseNames().ToList();
// dbs.ForEach(x => System.Console.WriteLine(x));

// get collection and model
var portfolioCollection = client.GetDatabase("PersonalDB").GetCollection<PortfolioContactModel>(collectionName);

portfolioCollection.InsertOne(new PortfolioContactModel("a","b","c","d"));

FilterDefinition<PortfolioContactModel> filter = Builders<PortfolioContactModel>.Filter.Eq("name", "a");
 
foreach (var result in portfolioCollection.Find(filter).ToList())
{
    System.Console.WriteLine($"{result.name}, {result.email}");
    // System.Console.WriteLine(String.Join(", ", ));
}



// var app = WebApplication.CreateBuilder(args).Build();
// app.MapGet("/", () => "This is a minimal api");
// app.Run();
