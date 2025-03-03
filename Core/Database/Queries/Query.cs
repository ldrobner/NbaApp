using System.Xml;
using MongoDB.Driver;

namespace NbaApp.Core.Database.Queries;

public abstract class Query {
    protected MongoConnector mongoConnector;
    public string Database { get; set; }
    public Query(MongoConnector mongoConnector, string? databaseName) {
        if(databaseName == null) {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\Constants\SeasonInfo.xml");
            Database = doc.GetElementById("Title").InnerText;
        } else {
            Database = databaseName;
        }
        this.mongoConnector = mongoConnector;
    }
}