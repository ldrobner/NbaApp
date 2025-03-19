using NbaApp.Core.Tools.Observer;

namespace NbaApp.Core.Types.ShotCharts;

public class ShotChart : Subject<Shot>{
    public ShotChartZones ShotChartZones { get => _shotChartZones; }
    private readonly ShotChartZones _shotChartZones;
    public ShotChartImage ShotChartImage { get => _shotChartImage; }
    private readonly ShotChartImage _shotChartImage;
    public ShotChartTimeSeries ShotChartTimeSeries { get => _shotChartTimeSeries; }
    private readonly ShotChartTimeSeries _shotChartTimeSeries;

    public ShotChart() : base() {
        _shotChartZones = new ShotChartZones();
        _shotChartImage = new ShotChartImage();
        _shotChartTimeSeries = new ShotChartTimeSeries();
        RegisterObserver(_shotChartZones);
        RegisterObserver(_shotChartImage);
    }

    public void AddShot(Shot shot) {
        UpdateObservers(shot);
        _shotChartTimeSeries.Accept(_shotChartZones);
    }
}