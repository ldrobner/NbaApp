using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using NbaApp.Core.Tools;

namespace NbaApp.Core.Database;

public class MongoConnector {
    private MongoClientSettings settings = new MongoClientSettings(){ // default is connect to localhost
        Scheme = ConnectionStringScheme.MongoDB,
        Server = new MongoServerAddress("127.0.0.1", 27017),
        ConnectTimeout = new TimeSpan(0, 0, 60),
        UseTls = true,
        DirectConnection = true,
        ServerSelectionTimeout = new TimeSpan(0, 0, 2),
        ApplicationName = "NbaWebApp"
    };
    private MongoClient mongoClient;

    private InMemCache<string, IMongoDatabase> InMemDbCache;
    private InMemCache<string, IMongoCollection<BsonDocument>> InMemCollectionCache;

    public MongoConnector(MongoClientSettings? settings) {
        if(settings == null) {
            this.mongoClient = new MongoClient(this.settings);
        } else {
            this.settings = settings;
            this.mongoClient = new MongoClient(settings);
        }
        this.InMemDbCache = new InMemCache<string, IMongoDatabase>(5);
        this.InMemCollectionCache = new InMemCache<string, IMongoCollection<BsonDocument>>(this.InMemDbCache.capacity * 5);
    }
    
    public MongoClientSettings getSettings() {
        return this.settings;
    }

    private IMongoDatabase GetDatabase(string dbName) {
        if(InMemDbCache.Contains(dbName)) {
            return this.InMemDbCache.Get(dbName);
        }
        return this.mongoClient.GetDatabase(dbName);
    }

    private IMongoCollection<BsonDocument> GetCollection(string dbName, string collectionName) {
        if(InMemCollectionCache.Contains(collectionName)) {
            return this.InMemCollectionCache.Get(collectionName);
        }
        IMongoDatabase db = this.GetDatabase(dbName);
        return db.GetCollection<BsonDocument>(collectionName);
    }

    /// <summary>
    /// Gets a single document or object from the specified collection
    /// </summary>
    /// <param name="dbName">The name of the database</param>
    /// <param name="collectionName">The name of the collection</param>
    /// <param name="filter">The filter used to lookup the document</param>
    /// <returns>A single document of type BsonDocument</returns>
    public BsonDocument GetDocument(string dbName, string collectionName, FilterDefinition<BsonDocument> filter) {
        IMongoCollection<BsonDocument> collection = this.GetCollection(dbName, collectionName);
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
        IMongoCollection<BsonDocument> collection = this.GetCollection(dbName, collectionName);
        return collection.Find(filter).ToList();
    }

    /// <summary>
    /// Inserts one or more documents or objects into the specified collection
    /// </summary>
    /// <param name="dbName">The name of the database</param>
    /// <param name="collectionName">The name of the collection</param>
    /// <param name="documents">The list of documents to be inserted into the collection</param>
    public void InsertDocuments(string dbName, string collectionName, List<BsonDocument> documents) {
        IMongoCollection<BsonDocument> collection = this.GetCollection(dbName, collectionName);
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
        IMongoCollection<BsonDocument> collection = this.GetCollection(dbName, collectionName);
        collection.UpdateMany(filter, update);
    }

    /// <summary>
    /// Deletes one or more documents or objects from a specified collection
    /// </summary>
    /// <param name="dbName">The name of the database</param>
    /// <param name="collectionName">The name of the collection</param>
    /// <param name="filter">The filter to be used to select which documents to be deleted</param>
    public void DeleteDocuments(string dbName, string collectionName, FilterDefinition<BsonDocument> filter) {
        IMongoCollection<BsonDocument> collection = this.GetCollection(dbName, collectionName);
        collection.DeleteMany(filter);
    }
}