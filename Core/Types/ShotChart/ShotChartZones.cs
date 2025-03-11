namespace NbaApp.Core.Types.ShotChart;

public class ShotChartZones {

    public ShotChartFragmentZone Total { get =>
        new("Total", new ShotChartFragmentZone[]{TwoPointers, ThreePointers});
    }

    public ShotChartFragmentZone TwoPointers { get =>
        new("TwoPointers", new ShotChartFragmentZone[]{_dunksAndLayups, MidRange});
    }

    public ShotChartFragmentZone DunksAndLayups {get => _dunksAndLayups; }
    private readonly ShotChartFragmentZone _dunksAndLayups;
    
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
        new("ThreePointers", new ShotChartFragmentZone[]{CornerThrees, AboveTheBreakThrees});
    }

    public ShotChartFragmentZone CornerThrees { get =>
        new("CornerThrees", new ShotChartFragmentZone[]{_leftCornerThreePointer, _rightCornerThreePointer});
    }

    public ShotChartFragmentZone AboveTheBreakThrees { get =>
        new("AboveTheBreakThrees", new ShotChartFragmentZone[]{_leftWingThreePointer, _centerThreePointer, _rightWingThreePointer});
    }

    public ShotChartFragmentZone LeftCornerThreePointer { get => _leftCornerThreePointer; }
    private readonly ShotChartFragmentZone _leftCornerThreePointer;

    public ShotChartFragmentZone LeftWingThreePointer { get => _leftWingThreePointer; }
    private readonly ShotChartFragmentZone _leftWingThreePointer;

    public ShotChartFragmentZone CenterThreePointer { get => _centerThreePointer; }
    private readonly ShotChartFragmentZone _centerThreePointer;

    public ShotChartFragmentZone RightWingThreePointer { get => _rightWingThreePointer; }
    private readonly ShotChartFragmentZone _rightWingThreePointer;

    public ShotChartFragmentZone RightCornerThreePointer { get => _rightCornerThreePointer; }
    private readonly ShotChartFragmentZone _rightCornerThreePointer;

    public ShotChartFragmentZone HeaveOrLongThree { get => _heaveOrLongThree; }
    private readonly ShotChartFragmentZone _heaveOrLongThree;

    public ShotChartZones() {
        _dunksAndLayups = new ShotChartFragmentZone(2, "DunksAndLayups");
        _shortMidRangeLeft = new ShotChartFragmentZone(2, "ShortMidRangeLeft");
        _shortMidRangeCenter = new ShotChartFragmentZone(2, "ShortMidRangeCenter");
        _shortMidRangeRight = new ShotChartFragmentZone(2, "ShortMidRangeRight");
        _longMidRangeBaselineLeft = new ShotChartFragmentZone(2, "LongMidRangeBaselineLeft");
        _longMidRangeWingLeft = new ShotChartFragmentZone(2, "LongMidRangeWingLeft");
        _longMidRangeElbowLeft = new ShotChartFragmentZone(2, "LongMidRangeElbowLeft");
        _longMidRangeCenter = new ShotChartFragmentZone(2, "LongMidRangeCenter");
        _longMidRangeElbowRight = new ShotChartFragmentZone(2, "LongMidRangeElbowRight");
        _longMidRangeWingRight = new ShotChartFragmentZone(2, "LongMidRangeWingRight");
        _longMidRangeBaselineRight = new ShotChartFragmentZone(2, "LongMidRangebaselineRight");
        _leftCornerThreePointer = new ShotChartFragmentZone(3, "LeftCornerThreePointer");
        _leftWingThreePointer = new ShotChartFragmentZone(3, "LeftWingThreePointer");
        _centerThreePointer = new ShotChartFragmentZone(3, "CenterThreePointer");
        _rightWingThreePointer = new ShotChartFragmentZone(3, "RightWingThreePointer");
        _rightCornerThreePointer = new ShotChartFragmentZone(3, "RightCornerThreePointer");
        _heaveOrLongThree = new ShotChartFragmentZone(3, "HeaveOrLongThree");
    }
}