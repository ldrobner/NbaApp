namespace NbaApp.Core.Types.Statistics;

public class Totals {    
    private float _minutesPlayed;
    public float MinutesPlayed { get => _minutesPlayed; set => _minutesPlayed = value;}

    private int _fieldGoalsMade;
    public int FieldGoalsMade { get => _fieldGoalsMade; set => _fieldGoalsMade = value;}

    private int _fieldGoalsAttempted;
    public int FieldGoalsAttempted { get => _fieldGoalsAttempted ; set => _fieldGoalsAttempted = value;}

    private int _threePointersMade;
    public int ThreePointersMade { get => _threePointersMade; set => _threePointersMade = value;}

    private int _threePointersAttempted;
    public int ThreePointersAttempted { get => _threePointersAttempted ; set => _threePointersAttempted = value;}

    private int _freeThrowsMade;
    public int FreeThrowsMade { get => _freeThrowsMade; set => _freeThrowsMade = value;}

    private int _freeThrowsAttempted;
    public int FreeThrowsAttempted { get => _freeThrowsAttempted; set => _freeThrowsAttempted = value;}

    private int _offensiveRebounds;
    public int OffensiveRebounds { get => _offensiveRebounds; set => _offensiveRebounds = value;}

    private int _defensiveRebounds;
    public int DefensiveRebounds { get => _defensiveRebounds; set => _defensiveRebounds = value;}

    public int TotalRebounds { get {return _offensiveRebounds + _defensiveRebounds;}}

    private int _assists;
    public int  Assists { get => _assists; set => _assists = value;}

    private int _steals;
    public int Steals { get => _steals; set => _steals = value;}

    private int _blocks;
    public int Blocks { get => _blocks; set => _blocks = value;}

    private int _turnovers;
    public int Turnovers { get => _turnovers; set => _turnovers = value;}

    private int _personalFouls;
    public int PersonalFouls { get => _personalFouls; set => _personalFouls = value;}

    private int _points;
    public int Points { get => _points; set => _points = value; }

    private float _plusMinus;
    public float PlusMinus { get => _plusMinus; set => _plusMinus = value;}

    private int _didNotPlays;
    public int DidNotPlays { get => _didNotPlays; set => _didNotPlays = value;}

    private int _starts;
    public int Starts { get => _starts; set => _starts = value;}

    private int _wins;
    public int Wins { get => _wins; set => _wins = value;}

    private int _overtimes;
    public int Overtimes { get => _overtimes; set => _overtimes = value;}

    public Totals(
        float minutesPlayed,
        int fieldGoalsMade, int fieldGoalsAttempted,
        int threePointersMade, int threePointersAttempted,
        int freeThrowsMade, int freeThrowsAttempted,
        int offensiveRebounds, int defensiveRebounds,
        int assists,
        int steals, int blocks,
        int turnovers, int personalFouls,
        int points,
        float plusMinus,
        int didNotPlays, int starts,
        int wins, int overtimes
    ) {
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