using System.Globalization;

namespace NbaApp.Core.Types;

public class Player {
    private string _id;
    public string Id { get => _id; set => _id = value; }

    private string _firstName;
    public string FirstName { get => _firstName; set => _firstName = value; }

    private string _lastName;
    public string LastName { get => _lastName; set => _lastName = value; }

    private float _height;
    public float Height { get => _height; set => _height = value; }

    private float _weight;
    public float Weight { get => _weight ; set => _weight = value; }

    private DateOnly _birthday;
    public DateOnly Birthday { get => _birthday ; set => _birthday = value; }

    private string _nationality;
    public string Nationality { get => _nationality; set => _nationality = value; }

    private string? _college;
    public string? College { get => _college; set => _college = value; }

    private int? _draftPick;
    public int? DraftPick { get => _draftPick; set{if(0 < value || value < 61) {_draftPick = value;}} }

    private int _experience;
    public int Experience { get => _experience; set {if(value > 0) {_experience = value;} else {_experience = 0;}} }
    
    public Player(
        string id,
        string firstName, string lastName,
        float height, float weight,
        DateOnly birthday,
        string nationality, string? college,
        int? draftPick,
        int experience
    ) {
        _id = id;
        _firstName = firstName;
        _lastName = lastName;
        _height = height;
        _weight = weight;
        _birthday = birthday;
        _nationality = nationality;
        _college = college;
        _draftPick = draftPick;
        _experience = experience;
    }
}