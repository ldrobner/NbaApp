namespace NbaApp.Core.Database.Queries;

public abstract class Query {
    protected MongoConnector mongoConnector;
    public string? database { get; set; }
    public string? collection { get; set; }
    public Query(MongoConnector mongoConnector) {
        this.mongoConnector = mongoConnector;
    }
}