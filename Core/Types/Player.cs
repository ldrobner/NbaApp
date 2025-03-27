using MongoDB.Bson.Serialization.Attributes;
using NbaApp.Core.Types.ShotCharts;
using NbaApp.Core.Types.Statistics;

namespace NbaApp.Core.Types;

[BsonIgnoreExtraElements]
public class Player {
    [BsonElement("id")]
    public string PlayerId { get => _playerId; set => _playerId = value; }
    private string _playerId;

    [BsonElement("firstName")]
    public string FirstName { get => _firstName; set => _firstName = value; }
    private string _firstName;

    [BsonElement("lastName")]
    public string LastName { get => _lastName; set => _lastName = value; }
    private string _lastName;

    [BsonElement("height")]
    public double Height { get => _height; set => _height = value; }
    private double _height;

    [BsonElement("weight")]
    public double Weight { get => _weight ; set => _weight = value; }
    private double _weight;

    [BsonElement("birthday")]
    public DateTime Birthday { get => _birthday ; set => _birthday = value; }
    private DateTime _birthday;

    [BsonElement("nationality")]
    public string Nationality { get => _nationality; set => _nationality = value; }
    private string _nationality;

    [BsonElement("college")]
    public string? College { get => _college; set => _college = value; }
    private string? _college;

    [BsonElement("draftPick")]
    public int? DraftPick { get => _draftPick; set{if(0 < value || value < 61) {_draftPick = value;}} }
    private int? _draftPick;

    [BsonElement("experience")]
    public int Experience { get => _experience; set {if(value > 0) {_experience = value;} else {_experience = 0;}} }
    private int _experience;

    public ShotChart ShotChart { get => _shotChart; }
    private readonly ShotChart _shotChart;

    public Totals? Totals { get => _totals; set => _totals = value; }
    private Totals? _totals;
    
    public Player(
        string playerId,
        string firstName, string lastName,
        double height, double weight,
        DateTime birthday,
        string nationality, string? college,
        int? draftPick,
        int experience
    ) {
        _playerId = playerId;
        _firstName = firstName;
        _lastName = lastName;
        _height = height;
        _weight = weight;
        _birthday = birthday;
        _nationality = nationality;
        _college = college;
        _draftPick = draftPick;
        _experience = experience;
        _shotChart = new ShotChart();
    }
}