using System.Text.RegularExpressions;
using MongoDB.Driver;

namespace NbaApp.Core.Database;

public class MongoConnector {
    private readonly string DatabaseConnectionSettings = "DatabaseInformation";
    private readonly MongoClientSettings settings;
    private readonly MongoClient mongoClient;

    public IEnumerable<string> DatabaseNames { get => _databaseNames; }
    private readonly IEnumerable<string> _databaseNames;

    public MongoConnector(IConfiguration configuration) {
        IConfigurationSection dbConnectionSettings = configuration.GetSection(DatabaseConnectionSettings);
        string connectionString = dbConnectionSettings.GetValue<string>("ConnectionString");
        settings = MongoClientSettings.FromConnectionString(connectionString);
        mongoClient = new MongoClient(connectionString);
        
        List<string> databaseNames = mongoClient.ListDatabaseNames().ToList();
        Regex dbNameRegex = new Regex(@"[0-9]{4}-[0-9]{2}");
        _databaseNames = databaseNames.Where( dbName => dbNameRegex.IsMatch(dbName));
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