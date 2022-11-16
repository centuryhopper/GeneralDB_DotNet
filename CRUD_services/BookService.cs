
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PorfolioDB.Models;
using GeneralDB.Settings;
using Microsoft.AspNetCore.Http.HttpResults;

namespace PortfolioDB.Services;

public class BookService
{
    private readonly IMongoCollection<BookModel> models;

    public BookService(IOptions<GeneralDBSettings> options)
    {
        var mongoClient = new MongoClient(options.Value.connectionString);

        models = mongoClient.GetDatabase(options.Value.DatabaseName).GetCollection<BookModel>(options.Value.collectionName!["Books"]);
    }

    public async Task<List<BookModel>> Get()
    {
        return await models.Find(_ => true).ToListAsync();
    }

    public async Task<BookModel> Get(string id)
    {
        return await models.Find(m => m.Id == id).FirstOrDefaultAsync();
    }

    public async Task Create(BookModel model)
    {
        await models.InsertOneAsync(model);
    }

    public async Task Update(string id, BookModel model)
    {
        await models.ReplaceOneAsync(m => m.Id == id, model);
    }

    public async Task Remove(string id)
    {
        await models.DeleteOneAsync(m => m.Id == id);
    }
}

