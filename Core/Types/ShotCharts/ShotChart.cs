using NbaApp.Core.Tools.Observer;

namespace NbaApp.Core.Types.ShotCharts;

public class ShotChart : Subject<Shot> {
    public ShotChartZones ShotChartZones { get => _shotChartZones; }
    private readonly ShotChartZones _shotChartZones;
    public ShotChartImage ShotChartImage { get => _shotChartImage; }
    private readonly ShotChartImage _shotChartImage;
    public List<(double EffectiveFieldGoalPct, double ThreePointAttemptRate)> ShotChartTimeSeries { get => _shotChartTimeSeries; }
    private readonly List<(double EffectiveFieldGoalPct, double ThreePointAttemptRate)> _shotChartTimeSeries;

    public ShotChart() : base() {
        _shotChartZones = new ShotChartZones();
        _shotChartImage = new ShotChartImage();
        RegisterObserver(_shotChartZones);
        RegisterObserver(_shotChartImage);

        _shotChartTimeSeries = new List<(double EffectiveFieldGoalPct, double ThreePointAttemptRate)>();
    }

    public void AddShot(Shot shot) {
        UpdateObservers(shot);
        
        ShotChartFragmentZone twoPointers = _shotChartZones.TwoPointers;
        ShotChartFragmentZone threePointers = ShotChartZones.ThreePointers;
        _shotChartTimeSeries.Add(
            (
                CalculateEffectiveFieldGoalPct(twoPointers, threePointers),
                CalculateThreePointAttemptRate(twoPointers, threePointers)
            )
        );
    }

    private double CalculateEffectiveFieldGoalPct(ShotChartFragmentZone twoPointers, ShotChartFragmentZone threePointers) {
        return (twoPointers.Makes + 0.5 * threePointers.Makes) / (twoPointers.Attempts + threePointers.Attempts);
    }

    private double CalculateThreePointAttemptRate(ShotChartFragmentZone twoPointers, ShotChartFragmentZone threePointers) {
        return threePointers.Attempts / (twoPointers.Attempts + threePointers.Attempts);
    }
}