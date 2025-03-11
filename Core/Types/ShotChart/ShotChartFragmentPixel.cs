namespace NbaApp.Core.Types.ShotChart;

public class ShotChartFragmentPixel : ShotChartFragment {

    public int Ix { get => _ix; }
    private readonly int _ix;

    public int Jx { get => _jx; }
    private readonly int _jx;

    private readonly Dictionary<int, double> _weightedValues;
    public ShotChartFragmentPixel(int points, int ix, int jx) : base(ShotChartFragmentType.Pixel, points) {
        _ix = ix;
        _jx = jx;
        _weightedValues = new Dictionary<int, double>();
    }

    public void UpdateWeightedValues(int key, double value) {
        _weightedValues[key] = value;
    }

    public double AdjValue(double foulRate, double freeThrowPercentage) {
        return Value(foulRate, freeThrowPercentage) + _weightedValues.Values.ToArray().Sum();
    }

    public double Value(double foulRate, double freeThrowPercentage) {
        return _points * (FieldGoalPectange() + foulRate * freeThrowPercentage);
    }
}