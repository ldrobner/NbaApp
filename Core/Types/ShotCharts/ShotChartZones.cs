namespace NbaApp.Core.Types.ShotCharts;

public class ShotChartZones : ShotChartCollection {

    public ShotChartFragmentZone Total { get =>
        new("Total", new ShotChartFragmentZone[]{TwoPointers, ThreePointers});
    }

    public ShotChartFragmentZone TwoPointers { get =>
        new("TwoPointers", new ShotChartFragmentZone[]{_layupsAndDunks, MidRange});
    }

    public ShotChartFragmentZone LayupsAndDunks {get => _layupsAndDunks; }
    private readonly ShotChartFragmentZone _layupsAndDunks;
    
    public ShotChartFragmentZone MidRange { get => 
        new("MidRange", new ShotChartFragmentZone[]{ShortMidRange, LongMidRange});
    }

    public ShotChartFragmentZone ShortMidRange { get =>
        new("ShortMidRange", new ShotChartFragmentZone[]{_shortMidRangeLeft, _shortMidRangeCenter, _shortMidRangeRight});
    }

    public ShotChartFragmentZone ShortMidRangeLeft { get => _shortMidRangeLeft; }
    private readonly ShotChartFragmentZone _shortMidRangeLeft;

    public ShotChartFragmentZone ShortMidRangeCenter { get => _shortMidRangeCenter; }
    private readonly ShotChartFragmentZone _shortMidRangeCenter;

    public ShotChartFragmentZone ShortMidRangeRight { get => _shortMidRangeRight; }
    private readonly ShotChartFragmentZone _shortMidRangeRight;

    public ShotChartFragmentZone LongMidRange { get =>
        new("LongMidRange", new ShotChartFragmentZone[]{
            LongMidRangeBaseline,
            LongMidRangeElbows,
            _longMidRangeWingLeft,
            _longMidRangeCenter,
            _longMidRangeWingRight
        });
    }

    public ShotChartFragmentZone LongMidRangeBaseline { get =>
        new("LongMidRangeBaseline", new ShotChartFragmentZone[]{_longMidRangeBaselineLeft, _longMidRangeBaselineRight});
    }

    public ShotChartFragmentZone LongMidRangeElbows { get =>
        new("LongMidRangeElbows", new ShotChartFragmentZone[]{_longMidRangeElbowLeft, _longMidRangeElbowRight});
    }

    public ShotChartFragmentZone LongMidRangeBaselineLeft { get => _longMidRangeBaselineLeft; }
    private readonly ShotChartFragmentZone _longMidRangeBaselineLeft;

    public ShotChartFragmentZone LongMidRangeWingLeft { get => _longMidRangeWingLeft; }
    private readonly ShotChartFragmentZone _longMidRangeWingLeft;

    public ShotChartFragmentZone LongMidRangeElbowLeft { get => _longMidRangeElbowLeft; }
    private readonly ShotChartFragmentZone _longMidRangeElbowLeft;

    public ShotChartFragmentZone LongMidRangeCenter { get => _longMidRangeCenter; }
    private readonly ShotChartFragmentZone _longMidRangeCenter;

    public ShotChartFragmentZone LongMidRangeElbowRight { get => _longMidRangeElbowRight; }
    private readonly ShotChartFragmentZone _longMidRangeElbowRight;

    public ShotChartFragmentZone LongMidRangeWingRight { get => _longMidRangeWingRight; }
    private readonly ShotChartFragmentZone _longMidRangeWingRight;

    public ShotChartFragmentZone LongMidRangeBaselineRight { get => _longMidRangeBaselineRight; }
    private readonly ShotChartFragmentZone _longMidRangeBaselineRight;

    public ShotChartFragmentZone ThreePointers { get =>
        new("ThreePointers", new ShotChartFragmentZone[]{ThreePointerCorner, ThreePointerAboveTheBreak});
    }

    public ShotChartFragmentZone ThreePointerCorner { get =>
        new("CornerThrees", new ShotChartFragmentZone[]{_threePointerCornerLeft, _threePointerCornerRight});
    }

    public ShotChartFragmentZone ThreePointerAboveTheBreak { get =>
        new("AboveTheBreakThrees", new ShotChartFragmentZone[]{_threePointerWingLeft, _threePointerCenter, _threePointerWingRight});
    }

    public ShotChartFragmentZone ThreePointerCornerLeft { get => _threePointerCornerLeft; }
    private readonly ShotChartFragmentZone _threePointerCornerLeft;

    public ShotChartFragmentZone ThreePointerWingLeft { get => _threePointerWingLeft; }
    private readonly ShotChartFragmentZone _threePointerWingLeft;

    public ShotChartFragmentZone ThreePointerCenter { get => _threePointerCenter; }
    private readonly ShotChartFragmentZone _threePointerCenter;

    public ShotChartFragmentZone ThreePointerWingRight { get => _threePointerWingRight; }
    private readonly ShotChartFragmentZone _threePointerWingRight;

    public ShotChartFragmentZone ThreePointerCornerRight { get => _threePointerCornerRight; }
    private readonly ShotChartFragmentZone _threePointerCornerRight;

    public ShotChartFragmentZone HeaveOrLongThree { get => _heaveOrLongThree; }
    private readonly ShotChartFragmentZone _heaveOrLongThree;

    public ShotChartZones() : base() {
        _layupsAndDunks = new ShotChartFragmentZone(2, "LayupsAndDunks");
        _shortMidRangeLeft = new ShotChartFragmentZone(2, "ShortMidRangeLeft");
        _shortMidRangeCenter = new ShotChartFragmentZone(2, "ShortMidRangeCenter");
        _shortMidRangeRight = new ShotChartFragmentZone(2, "ShortMidRangeRight");
        _longMidRangeBaselineLeft = new ShotChartFragmentZone(2, "LongMidRangeBaselineLeft");
        _longMidRangeWingLeft = new ShotChartFragmentZone(2, "LongMidRangeWingLeft");
        _longMidRangeElbowLeft = new ShotChartFragmentZone(2, "LongMidRangeElbowLeft");
        _longMidRangeCenter = new ShotChartFragmentZone(2, "LongMidRangeCenter");
        _longMidRangeElbowRight = new ShotChartFragmentZone(2, "LongMidRangeElbowRight");
        _longMidRangeWingRight = new ShotChartFragmentZone(2, "LongMidRangeWingRight");
        _longMidRangeBaselineRight = new ShotChartFragmentZone(2, "LongMidRangeBaselineRight");
        _threePointerCornerLeft = new ShotChartFragmentZone(3, "ThreePointerCornerLeft");
        _threePointerWingLeft = new ShotChartFragmentZone(3, "ThreePointerWingLeft");
        _threePointerCenter = new ShotChartFragmentZone(3, "ThreePointerCenter");
        _threePointerWingRight = new ShotChartFragmentZone(3, "ThreePointerWingRight");
        _threePointerCornerRight = new ShotChartFragmentZone(3, "ThreePointerCornerRight");
        _heaveOrLongThree = new ShotChartFragmentZone(3, "HeaveOrLongThree");
    }

    public override void Update(Shot shot)
    {
        if(IsLayupOrDunk(shot.Left, shot.Top)) { _layupsAndDunks.AddShot(shot); } 
        else if(IsShortMidRangeLeft(shot.Left, shot.Top)) { _shortMidRangeLeft.AddShot(shot); }
        else if(IsShortMidRangeCenter(shot.Left, shot.Top)) { _shortMidRangeCenter.AddShot(shot); }
        else if(IsShortMidRangeRight(shot.Left, shot.Top)) { _shortMidRangeRight.AddShot(shot); } 
        else if(IsLongMidRangeBaselineLeft(shot.Left, shot.Top)) { _longMidRangeBaselineLeft.AddShot(shot); }
        else if(IsLongMidRangeWingLeft(shot.Left, shot.Top)) { _longMidRangeWingLeft.AddShot(shot); }
        else if(IsLongMidRangeElbowLeft(shot.Left, shot.Top)) { _longMidRangeElbowLeft.AddShot(shot); }
        else if(IsLongMidRangeCenter(shot.Left, shot.Top)) { _longMidRangeCenter.AddShot(shot); }
        else if(IsLongMidRangeElbowRight(shot.Left, shot.Top)) { _longMidRangeElbowRight.AddShot(shot); }
        else if(IsLongMidRangeWingRight(shot.Left, shot.Top)) { _longMidRangeWingRight.AddShot(shot); }
        else if(IsLongMidRangeBaselineRight(shot.Left, shot.Top)) { _longMidRangeBaselineRight.AddShot(shot); }
        else if(IsThreePointerCornerLeft(shot.Left, shot.Top)) { _threePointerCornerLeft.AddShot(shot); }
        else if(IsThreePointerWingLeft(shot.Left, shot.Top)) { _threePointerWingLeft.AddShot(shot); }
        else if(IsThreePointerCenter(shot.Left, shot.Top)) { _threePointerCenter.AddShot(shot); }
        else if(IsThreePointerWingRight(shot.Left, shot.Top)) { _threePointerWingRight.AddShot(shot); }
        else if(IsThreePointerCornerRight(shot.Left, shot.Top)) { _threePointerCornerRight.AddShot(shot); }
        else if(IsThreePointerHeave(shot.Left, shot.Top)) { _heaveOrLongThree.AddShot(shot); }
        else { throw new Exception($"Shot with ix {shot.Left} and jx {shot.Top} does not fall within a zone!"); }
    }
}