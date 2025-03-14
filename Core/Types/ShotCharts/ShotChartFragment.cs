namespace NbaApp.Core.Types.ShotCharts;

public abstract class ShotChartFragment {
    public ShotChartFragmentType Type { get => _type; }
    private ShotChartFragmentType _type;

    public int Points  { get => _points; }
    protected int _points;

    public int Attempts { get => _attempts; set => _attempts = value; }
    protected int _attempts;

    public int Makes { get => _makes; set => _makes = value; }
    protected int _makes;

    public int Assisteds { get => _assisteds; set => _assisteds = value; }
    protected int _assisteds;

    public ShotChartFragment(ShotChartFragmentType type, int points) {
        _type = type;
        _points = points;
        _attempts = 0;
        _makes = 0;
        _assisteds = 0;
    }

    public double FieldGoalPectange() {
        return _makes / _attempts;
    }

    public void AddShot(Shot shot)
    {
        _attempts += 1;
        _makes += shot.Make ? 1 : 0;
        _assisteds += shot.Assisted ? 1 : 0;
    }
}