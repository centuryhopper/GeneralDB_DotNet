
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PorfolioDB.Models;
using PortfolioDB.Settings;

namespace PortfolioDB.Services;

public class PortfolioContactService
{
    private readonly IMongoCollection<PortfolioContactModel> models;

    public PortfolioContactService(IOptions<PortfolioDBSettings> options)
    {
        var mongoClient = new MongoClient(options.Value.connectionString);

        models = mongoClient.GetDatabase(options.Value.DatabaseName).GetCollection<PortfolioContactModel>(options.Value.collectionName);

    }

    public async Task<List<PortfolioContactModel>> Get()
    {
        return await models.Find(_ => true).ToListAsync();
    }

    public async Task<PortfolioContactModel> Get(string id)
    {
        return await models.Find(m => m.Id == id).FirstOrDefaultAsync();
    }

    public async Task Create(PortfolioContactModel model)
    {
        await models.InsertOneAsync(model);
    }

    public async Task Update(string id, PortfolioContactModel model)
    {
        await models.ReplaceOneAsync(m => m.Id == id, model);
    }

    public async Task Remove(string id)
    {
        await models.DeleteOneAsync(m => m.Id == id);
    }
}

