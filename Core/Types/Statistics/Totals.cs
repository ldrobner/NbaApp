using MongoDB.Bson.Serialization.Attributes;

namespace NbaApp.Core.Types.Statistics;

public class Totals {
    [BsonElement("pid")]
    public string PlayerId { get => _playerId; set => _playerId = value; }
    private string _playerId;

    [BsonElement("mp")]
    public double MinutesPlayed { get => _minutesPlayed; set => _minutesPlayed = value;}
    private double _minutesPlayed;

    [BsonElement("fg")]
    public int FieldGoalsMade { get => _fieldGoalsMade; set => _fieldGoalsMade = value;}
    private int _fieldGoalsMade;

    [BsonElement("fga")]
    public int FieldGoalsAttempted { get => _fieldGoalsAttempted ; set => _fieldGoalsAttempted = value;}
    private int _fieldGoalsAttempted;

    [BsonElement("fg3")]
    public int ThreePointersMade { get => _threePointersMade; set => _threePointersMade = value;}
    private int _threePointersMade;

    [BsonElement("fg3a")]
    public int ThreePointersAttempted { get => _threePointersAttempted ; set => _threePointersAttempted = value;}
    private int _threePointersAttempted;

    [BsonElement("ft")]
    public int FreeThrowsMade { get => _freeThrowsMade; set => _freeThrowsMade = value;}
    private int _freeThrowsMade;

    [BsonElement("fta")]
    public int FreeThrowsAttempted { get => _freeThrowsAttempted; set => _freeThrowsAttempted = value;}
    private int _freeThrowsAttempted;

    [BsonElement("orb")]
    public int OffensiveRebounds { get => _offensiveRebounds; set => _offensiveRebounds = value;}
    private int _offensiveRebounds;

    [BsonElement("drb")]
    public int DefensiveRebounds { get => _defensiveRebounds; set => _defensiveRebounds = value;}
    private int _defensiveRebounds;

    public int TotalRebounds { get {return _offensiveRebounds + _defensiveRebounds;}}

    [BsonElement("ast")]
    public int  Assists { get => _assists; set => _assists = value;}
    private int _assists;

    [BsonElement("stl")]
    public int Steals { get => _steals; set => _steals = value;}
    private int _steals;

    [BsonElement("blk")]
    public int Blocks { get => _blocks; set => _blocks = value;}
    private int _blocks;

    [BsonElement("tov")]
    public int Turnovers { get => _turnovers; set => _turnovers = value;}
    private int _turnovers;

    [BsonElement("pf")]
    public int PersonalFouls { get => _personalFouls; set => _personalFouls = value;}
    private int _personalFouls;

    [BsonElement("pts")]
    public int Points { get => _points; set => _points = value; }
    private int _points;

    [BsonElement("game_score")]
    public double GameScore { get => _gameScore; set => _gameScore = value;}
    private double _gameScore;

    [BsonElement("plus_minus")]
    public double PlusMinus { get => _plusMinus; set => _plusMinus = value;}
    private double _plusMinus;

    [BsonElement("dnp")]
    public int DidNotPlays { get => _didNotPlays; set => _didNotPlays = value;}
    private int _didNotPlays;

    [BsonElement("gs")]
    public int Starts { get => _starts; set => _starts = value;}
    private int _starts;

    [BsonElement("win")]
    public int Wins { get => _wins; set => _wins = value;}
    private int _wins;

    [BsonElement("overtime")]
    public int Overtimes { get => _overtimes; set => _overtimes = value;}
    private int _overtimes;

    public Totals(
        string playerId,
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
        int wins, int overtimes
    ) {
        _playerId = playerId;
        _minutesPlayed = minutesPlayed;
        _fieldGoalsMade = fieldGoalsMade;
        _fieldGoalsAttempted = fieldGoalsAttempted;
        _threePointersMade = threePointersMade;
        _threePointersAttempted = threePointersAttempted;
        _freeThrowsMade = freeThrowsMade;
        _freeThrowsAttempted = freeThrowsAttempted;
        _offensiveRebounds = offensiveRebounds;
        _defensiveRebounds = defensiveRebounds;
        _assists = assists;
        _steals = steals;
        _blocks = blocks;
        _turnovers = turnovers;
        _personalFouls = personalFouls;
        _points = points;
        _plusMinus = plusMinus;
        _didNotPlays = didNotPlays;
        _starts = starts;
        _wins = wins;
        _overtimes = overtimes;
    }
}