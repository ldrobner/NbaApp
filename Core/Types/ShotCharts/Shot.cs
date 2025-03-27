using MongoDB.Bson.Serialization.Attributes;

namespace NbaApp.Core.Types.ShotCharts;

[BsonIgnoreExtraElements]
public class Shot {
    
    [BsonElement("top")]
    public int Top { get => _top; set => _top = value; }
    private int _top;
    
    [BsonElement("left")]
    public int Left { get => _left; set => _left = value; }
    private int _left;

    [BsonElement("distance")]
    public int Distance { get => _distance; set => _distance = value; }
    private int _distance;
    [BsonElement("make")]
    public bool Make { get => _make; set => _make = value; }
    private bool _make;

    [BsonElement("quarter")]
    public int Quater { get => _quarter; set => _quarter = value; }
    private int _quarter;

    [BsonElement("clock")]
    public double Clock { get => _clock; set => _clock = value; }
    private double _clock;

    [BsonElement("date")]
    public DateTime Date { get => _date; set => _date = value; }
    private DateTime _date;

    [BsonElement("assisted")]
    public bool Assisted { get => _assisted; set => _assisted = value; }
    private bool _assisted;

    [BsonElement("assistor")]
    public string? Assistor { get => _assistor; set => _assistor = value; }
    private string? _assistor;

    public Shot(
        int top, int left, int distance,
        bool make,
        int quarter, double clock,
        DateTime date,
        bool assisted, string assistor
    ) {
        _top = top;
        _left = left;
        _distance = distance;
        _make = make;
        _quarter = quarter;
        _clock = clock;
        _date = date;
        _assisted = assisted;
        _assistor = assistor;
    }
}