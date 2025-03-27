using MongoDB.Driver;
using NbaApp.Core.Types;
using NbaApp.Core.Types.ShotCharts;
using NbaApp.Core.Types.Statistics;

namespace NbaApp.Core.Database.Queries;

public class PlayerQuery : Query {
    public PlayerQuery(MongoConnector mongoConnector, string databaseName) : base (mongoConnector, databaseName) {}

    public List<Player> GetPlayers() {
        FilterDefinition<Player> filter = Builders<Player>.Filter.Empty;
        IMongoCollection<Player> collection = mongoConnector.GetCollection<Player>(Database, "players");
        return collection.Find(filter).ToList();
    }

    public Player GetPlayerById(string playerId) {
        FilterDefinition<Player> filter = Builders<Player>.Filter.Eq("PlayerId", playerId);
        IMongoCollection<Player> collection = mongoConnector.GetCollection<Player>(Database, "players");
        return collection.Find(filter).FirstOrDefault();
    }

    public List<Player> GetPlayerByName(string fname, string lname) {
        FilterDefinitionBuilder<Player> builder = Builders<Player>.Filter;
        FilterDefinition<Player> filter = builder.Eq("firstName", fname) & builder.Eq("lastName", lname);
        IMongoCollection<Player> collection = mongoConnector.GetCollection<Player>(Database, "players");
        return collection.Find(filter).ToList();
    }

    public List<BoxScore> GetBoxScoresByPlayerId(string playerId, DateOnly? start, DateOnly? end) {
        FilterDefinitionBuilder<BoxScore> builder = Builders<BoxScore>.Filter;
        FilterDefinition<BoxScore> filter = builder.Eq("pid", playerId);
        if(start != null) {
            filter &= builder.Gte("date", start);
        }

        if(end != null) {
            filter &= builder.Lte("date", end);
        }
        
        IMongoCollection<BoxScore> collection = mongoConnector.GetCollection<BoxScore>(Database, "box-scores");
        return collection.Find(filter).ToList();
    }

    public Totals GetTotalsById(string playerId, DateOnly? start, DateOnly? end) {
        IMongoCollection<BoxScore> collection = mongoConnector.GetCollection<BoxScore>(Database, "box-scores");
        FilterDefinitionBuilder<BoxScore> builder = Builders<BoxScore>.Filter;
        FilterDefinition<BoxScore> filter = builder.Eq("pid", playerId);
        if(start != null) {
            filter &= builder.Gte("date", start);
        }

        if(end != null) {
            filter &= builder.Lte("date", end);
        }

        PipelineDefinition<BoxScore, Totals> pipeline = new EmptyPipelineDefinition<BoxScore>()
            .Match(filter)
            .Group( 
                tot => tot.PlayerId,
                tot => new Totals(
                    tot.Key,
                    tot.Sum(gl => gl.MinutesPlayed),
                    tot.Sum(gl => gl.FieldGoalsMade),
                    tot.Sum(gl => gl.FieldGoalsAttempted),
                    tot.Sum(gl => gl.ThreePointersMade),
                    tot.Sum(gl => gl.ThreePointersAttempted),
                    tot.Sum(gl => gl.FreeThrowsMade),
                    tot.Sum(gl => gl.FreeThrowsAttempted),
                    tot.Sum(gl => gl.OffensiveRebounds),
                    tot.Sum(gl => gl.DefensiveRebounds),
                    tot.Sum(gl => gl.Assists),
                    tot.Sum(gl => gl.Steals),
                    tot.Sum(gl => gl.Blocks),
                    tot.Sum(gl => gl.Turnovers),
                    tot.Sum(gl => gl.PersonalFouls),
                    tot.Sum(gl => gl.Points),
                    tot.Sum(gl => gl.PlusMinus),
                    tot.Sum(gl => gl.DidNotPlays),
                    tot.Sum(gl => gl.Starts),
                    tot.Sum(gl => gl.Wins),
                    tot.Sum(gl => gl.Overtimes)
                )
            );
        return collection.Aggregate(pipeline).FirstOrDefault();
    }

    public List<Shot> GetShotsById(string playerId, DateOnly? start, DateOnly? end) {
        IMongoCollection<Shot> collection = mongoConnector.GetCollection<Shot>(Database, "shot-charts");
        FilterDefinitionBuilder<Shot> builder = Builders<Shot>.Filter;
        FilterDefinition<Shot> filter = builder.Eq("pid", playerId);
        if(start != null) {
            filter &= builder.Gte("date", start);
        }

        if(end != null) {
            filter &= builder.Lte("date", end);
        }
        return collection.Find(filter).ToList();
    }
}