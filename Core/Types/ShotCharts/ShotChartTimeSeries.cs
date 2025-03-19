using NbaApp.Core.Tools.Visitor;

namespace NbaApp.Core.Types.ShotCharts;

public class ShotChartTimeSeries : VisitorElement<ShotChartZones, IShotChartTimeStamp>
{
    public ShotChartTimeSeries() : base() {}

    private static double CalculateEffectiveFieldGoalPct(ShotChartFragmentZone twoPointers, ShotChartFragmentZone threePointers) {
        return (twoPointers.Makes + 0.5 * threePointers.Makes) / (twoPointers.Attempts + threePointers.Attempts);
    }

    private static double CalculateThreePointAttemptRate(ShotChartFragmentZone twoPointers, ShotChartFragmentZone threePointers) {
        return threePointers.Attempts / (twoPointers.Attempts + threePointers.Attempts);
    }

    public override void Accept(ShotChartZones visitor)
    {
        ShotChartFragmentZone twoPointers = visitor.TwoPointers;
        ShotChartFragmentZone threePointers = visitor.ThreePointers;

        IShotChartTimeStamp ts = (IShotChartTimeStamp)new object();
        ts.EffectiveFieldGoalPct = CalculateEffectiveFieldGoalPct(twoPointers, threePointers);
        ts.ThreePointAttemptRate = CalculateThreePointAttemptRate(twoPointers, threePointers);

        _records.Add(ts);
    }
}