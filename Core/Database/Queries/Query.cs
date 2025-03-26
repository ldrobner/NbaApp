namespace NbaApp.Core.Database.Queries;

public abstract class Query {
    protected MongoConnector mongoConnector;
    public string Database { get; set; }
    public Query(MongoConnector mongoConnector, string databaseName) {
        Database = databaseName;
        this.mongoConnector = mongoConnector;
    }
}