namespace NbaApp.Core.Types;

public class ShotChartFragment {
    public int Points  { get => _points; }
    private int _points;

    public int Ix { get => _ix; }
    private readonly int _ix;

    public int Jx { get => _jx; }
    private readonly int _jx;

    public int Attempts { get => _attempts; set => _attempts = value; }
    private int _attempts;

    public int Makes { get => _makes; set => _makes = value; }
    private int _makes;

    public int Assisteds { get => _assisteds; set => _assisteds = value; }
    private int _assisteds;

    private readonly Dictionary<int, double> _weightedValues;

    public ShotChartFragment(int points, int ix, int jx) {
        _points = points;
        _ix = ix;
        _jx = jx;
        _attempts = 0;
        _makes = 0;
        _assisteds = 0;
        _weightedValues = new Dictionary<int, double>();
    }

    public void UpdateWeightedValues(int key, double value) {
        _weightedValues[key] = value;
    }

    public double FieldGoalPectange() {
        return _makes / _attempts;
    }

    public double EffectFieldGoalPercentage() {
        return _points / 2 * _makes / _attempts;
    }

    public double AdjValue(double foulRate, double freeThrowPercentage) {
        return Value(foulRate, freeThrowPercentage) + _weightedValues.Values.ToArray().Sum();
    }

    public double Value(double foulRate, double freeThrowPercentage) {
        return _points * (FieldGoalPectange() + foulRate * freeThrowPercentage);
    }
}