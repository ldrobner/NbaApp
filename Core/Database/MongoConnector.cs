using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using NbaApp.Core.Tools;

namespace NbaApp.Core.Database;

public class MongoConnector : IMongoConnector {
    private readonly string DatabaseConnectionSettings = "DatabaseInformation";
    private readonly MongoClientSettings settings;
    private readonly MongoClient mongoClient;
    private readonly InMemCache<string, IMongoDatabase> InMemDbCache;
    private readonly InMemCache<string, IMongoCollection<dynamic>> InMemCollectionCache;

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
        InMemDbCache = new InMemCache<string, IMongoDatabase>(5);
        InMemCollectionCache = new InMemCache<string, IMongoCollection<dynamic>>(InMemDbCache.capacity * 5);
    }
    
    public MongoClientSettings GetSettings() {
        return settings;
    }

    public IMongoDatabase GetDatabase(string dbName) {
        if(InMemDbCache.Contains(dbName)) {
            return InMemDbCache.Get(dbName);
        }
        return mongoClient.GetDatabase(dbName);
    }

    public IMongoCollection<T> GetCollection<T>(string dbName, string collectionName) {
        if(InMemCollectionCache.Contains(collectionName)) {
            return (IMongoCollection<T>)InMemCollectionCache.Get(collectionName);
        }
        IMongoDatabase db = GetDatabase(dbName);
        return db.GetCollection<T>(collectionName);
    }
/*
    /// <summary>
    /// Gets a single document or object from the specified collection
    /// </summary>
    /// <param name="dbName">The name of the database</param>
    /// <param name="collectionName">The name of the collection</param>
    /// <param name="filter">The filter used to lookup the document</param>
    /// <returns>A single document of type BsonDocument</returns>
    public BsonDocument GetDocument(string dbName, string collectionName, FilterDefinition<BsonDocument> filter) {
        IMongoCollection<BsonDocument> collection = GetCollection(dbName, collectionName);
        return collection.Find(filter).FirstOrDefault();
    }
    
    /// <summary>
    /// Gets many documents or objects from the specific collection
    /// </summary>
    /// <param name="dbName">The name of the database</param>
    /// <param name="collectionName">The name of the collection</param>
    /// <param name="filter">The filter used to lookup the document(s)</param>
    /// <returns>A list of doucments of type List<BsonDocument></returns>
    public List<BsonDocument> GetDocuments(string dbName, string collectionName, FilterDefinition<BsonDocument> filter) {
        IMongoCollection<BsonDocument> collection = GetCollection(dbName, collectionName);
        return collection.Find(filter).ToList();
    }

    /// <summary>
    /// Inserts one or more documents or objects into the specified collection
    /// </summary>
    /// <param name="dbName">The name of the database</param>
    /// <param name="collectionName">The name of the collection</param>
    /// <param name="documents">The list of documents to be inserted into the collection</param>
    public void InsertDocuments(string dbName, string collectionName, List<BsonDocument> documents) {
        IMongoCollection<BsonDocument> collection = GetCollection(dbName, collectionName);
        collection.InsertMany(documents);
    }

    /// <summary>
    /// Updates one or more documents or objects in the specified collection
    /// </summary>
    /// <param name="dbName">The name of the database</param>
    /// <param name="collectionName">The name of the collection</param>
    /// <param name="filter">The filter to be used to select which documents to be updated</param>
    /// <param name="update">The update to be applied to selected documents</param>
    public void UpdateDocuments(string dbName, string collectionName, FilterDefinition<BsonDocument> filter, UpdateDefinition<BsonDocument> update) {
        IMongoCollection<BsonDocument> collection = GetCollection(dbName, collectionName);
        collection.UpdateMany(filter, update);
    }

    /// <summary>
    /// Deletes one or more documents or objects from a specified collection
    /// </summary>
    /// <param name="dbName">The name of the database</param>
    /// <param name="collectionName">The name of the collection</param>
    /// <param name="filter">The filter to be used to select which documents to be deleted</param>
    public void DeleteDocuments(string dbName, string collectionName, FilterDefinition<BsonDocument> filter) {
        IMongoCollection<BsonDocument> collection = GetCollection(dbName, collectionName);
        collection.DeleteMany(filter);
    }
*/
}