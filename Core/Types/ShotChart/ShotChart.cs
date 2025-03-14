using NbaApp.Core.Tools.Observer;

namespace NbaApp.Core.Types.ShotChart;

public class ShotChart : Subject<Shot> {
    public ShotChartZones ShotChartZones { get => _shotChartZones; }
    private ShotChartZones _shotChartZones;

    public ShotChartImage ShotChartImage { get => _shotChartImage; }
    private ShotChartImage _shotChartImage;

    public ShotChart() : base() {
        _shotChartZones = new ShotChartZones();
        _shotChartImage = new ShotChartImage();
        RegisterObserver(_shotChartZones);
        RegisterObserver(_shotChartImage);
    }

    public void AddShot(Shot shot) {
        UpdateObservers(shot);
    }
}