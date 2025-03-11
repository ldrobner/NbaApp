namespace NbaApp.Core.Types.ShotChart;

public class ShotChartFragmentZone : ShotChartFragment {
    public string Name { get => _name; }
    private readonly string _name;

    public ShotChartFragmentZone(int points, string name) : base(ShotChartFragmentType.Zone, points) {
        _name = name;
    }

    public ShotChartFragmentZone(string name, params ShotChartFragmentZone[] zones) : base(ShotChartFragmentType.Zone, zones[0].Points) {
        _name = name;
        foreach (ShotChartFragmentZone zone in zones) {
            if(zone.Points != _points) {
                throw new Exception("Cannot add shot chart zone with different point values!");
            }
            _makes += zone.Makes;
            _attempts += zone.Attempts;
            _assisteds += zone.Assisteds;
        }
    }
}