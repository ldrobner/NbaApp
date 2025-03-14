namespace NbaApp.Core.Types.ShotCharts;

public class Shot {
    private int _top;
    public int Top { get => _top; set => _top = value; }

    private int _left;
    public int Left { get => _left; set => _left = value; }

    private int _distance;
    public int Distance { get => _distance; set => _distance = value; }

    private bool _make;
    public bool Make { get => _make; set => _make = value; }

    private int _quarter;
    public int Quater { get => _quarter; set => _quarter = value; }

    private double _clock;
    public double Clock { get => _clock; set => _clock = value; }

    private DateOnly _date;
    public DateOnly Date { get => _date; set => _date = value; }

    private bool _assisted;
    public bool Assisted { get => _assisted; set => _assisted = value; }

    private string? _assistor;
    public string? Assistor { get => _assistor; set => _assistor = value; }

    public Shot(
        int top, int left, int distance,
        bool make,
        int quarter, double clock,
        DateOnly date,
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