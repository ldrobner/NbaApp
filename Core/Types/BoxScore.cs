using MongoDB.Bson.Serialization.Attributes;
using NbaApp.Core.Types.Statistics;

namespace NbaApp.Core.Types;

public class BoxScore : Totals {

    [BsonElement("team")]
    public string Team { get => _team; set => _team = value; }
    private string _team;

    [BsonElement("opp")]
    public string Opponent { get => _opponent; set => _opponent = value; }
    private string _opponent;

    [BsonElement("date")]
    public DateOnly Date { get => _date; set => _date = value; }
    private DateOnly _date;

    public BoxScore(string playerId,
        double minutesPlayed,
        int fieldGoalsMade, int fieldGoalsAttempted,
        int threePointersMade, int threePointersAttempted,
        int freeThrowsMade, int freeThrowsAttempted,
        int offensiveRebounds, int defensiveRebounds,
        int assists,
        int steals, int blocks,
        int turnovers, int personalFouls,
        int points,
        double plusMinus,
        int didNotPlays, int starts,
        int wins, int overtimes,
        string team, string opponent,
        DateOnly date) : 
            base(playerId,
                minutesPlayed,
                fieldGoalsMade, fieldGoalsAttempted,
                threePointersMade, threePointersAttempted,
                freeThrowsMade, freeThrowsAttempted,
                offensiveRebounds, defensiveRebounds,
                assists,
                steals, blocks,
                turnovers, personalFouls,
                points,
                plusMinus,
                didNotPlays, starts,
                wins, overtimes
            ) 
    {
            _team = team;
            _opponent = opponent;
            _date = date;
    }
}