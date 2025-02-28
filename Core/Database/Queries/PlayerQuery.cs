using NbaApp.Core.Types;
using NbaApp.Core.Types.Statistics;

namespace NbaApp.Core.Database.Queries;

public class PlayerQuery : Query {
    public PlayerQuery(MongoConnector mongoConnector) : base (mongoConnector) {}
    public List<Player> GetPlayers() {
        return new List<Player>();
    }
    public Player GetPlayerById(string playerId) {
        return new Player("", "", "", 0, 0, new DateOnly(), "", null, null, 0);
    }
    public List<Player> GetPlayerByTeam(TeamInfo team) {
        return new List<Player>();
    }
    public Totals GetTotalsById(string playerId) {
        return new Totals(0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0);
    }
    public List<Shot> GetShotsById(string playerId) {
        return new List<Shot>();
    }
    public List<Shot> GetShotsFromGameById(string playerId, DateOnly gameDate) {
        return new List<Shot>();
    }
    public List<Play> GetPlaysById(string playerId) {
        return new List<Play>();
    }
    public List<Play> GetPlaysFromGameById(string playerId, DateOnly gameDate) {
        return new List<Play>();
    }
}