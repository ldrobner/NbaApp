using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using NbaApp.Core.Tools;

namespace NbaApp.Core.Database;

public class MongoConnector : IMongoConnector {
    private readonly string DatabaseConnectionSettings = "DatabaseInformation";
    private readonly MongoClientSettings settings;
    private readonly MongoClient mongoClient;

    public MongoConnector(IConfiguration configuration) {
        IConfigurationSection dbConnectionSettings = configuration.GetSection(DatabaseConnectionSettings);
        settings = new() {
            Scheme = dbConnectionSettings.GetValue<string>("Scheme").Equals("mongodb") ? 
                ConnectionStringScheme.MongoDB : 
                ConnectionStringScheme.MongoDBPlusSrv,
            Server = new MongoServerAddress(
                dbConnectionSettings.GetValue<string>("SeverAddress"), 
                dbConnectionSettings.GetValue<int>("ServerPort")),
            ConnectTimeout = new TimeSpan(0,0,dbConnectionSettings.GetValue<int>("ConnectionTimeoutSeconds")),
            UseTls = dbConnectionSettings.GetValue<bool>("UseTls"),
            DirectConnection = dbConnectionSettings.GetValue<bool>("DirectConnection"),
            ServerSelectionTimeout = new TimeSpan(0,0,dbConnectionSettings.GetValue<int>("ServerSelectionTimeoutSeconds")),
            ApplicationName = dbConnectionSettings.GetValue<string>("ApplicationName")
        };
        mongoClient = new MongoClient(settings);
    }
    
    public MongoClientSettings GetSettings() {
        return settings;
    }

    public IMongoDatabase GetDatabase(string dbName) {
        return mongoClient.GetDatabase(dbName);
    }

    public IMongoCollection<T> GetCollection<T>(string dbName, string collectionName) {
        IMongoDatabase db = GetDatabase(dbName);
        return db.GetCollection<T>(collectionName);
    }
}