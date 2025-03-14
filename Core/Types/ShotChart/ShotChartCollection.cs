using NbaApp.Core.Tools.Observer;

namespace NbaApp.Core.Types.ShotChart;

public abstract class ShotChartCollection : Observer<Shot> {

    #region Constants

    private static (int x, int y) BasketPosition = (250, 55);
    private static (int x, int y) LeftElbowPosition = (170, 190);
    private static (int x, int y) RightElbowPosition = (328, 190);

    #endregion

    public ShotChartCollection() : base() {}

    protected static double GetDistance(int x1, int y1, int x2, int y2) {
        return Math.Sqrt(
            Math.Pow(x1-x2,2) + Math.Pow(y1-y2,2)
        ) / 10;
    }

    protected static double GetAngle(double x, double y) {
        return 180 / Math.PI * Math.Atan(x/y);
    }

    #region Zone Finders

    protected static bool IsThreePointerCornerLeft(int ix, int jx) {
        return 0 <= ix && ix < 30 && 0 <= jx && jx <= 140;
    }

    protected static bool IsThreePointerCornerRight(int ix, int jx) {
        return 469 < ix && ix <= 500 && 0 <= jx && jx <= 140;
    }

    protected static bool IsCornerThree(int ix, int jx) {
        return 0 <= jx && jx <= 140 && (0 <= ix && ix < 30 || 469 < ix && ix <= 500);
    }

    protected static bool IsLayupOrDunk(int ix, int jx) {
        double distance = GetDistance(ix, jx, BasketPosition.x, BasketPosition.y);
        return distance <= 3;
    }

    protected static bool IsShortMidRange(int ix, int jx) {
        double distance = GetDistance(ix, jx, BasketPosition.x, BasketPosition.y);
        return 3 < distance && distance < 8.2;
    }

    protected static bool IsShortMidRangeLeft(int ix, int jx) {
        double angle = GetAngle(ix-BasketPosition.x,jx-BasketPosition.y);
        return IsShortMidRange(ix, jx) && -90 <= angle && angle <= -45;
    }

    protected static bool IsShortMidRangeCenter(int ix, int jx) {
        double angle = GetAngle(ix-BasketPosition.x,jx-BasketPosition.y);
        return IsShortMidRange(ix, jx) && -45 < angle && angle < 45;
    }

    protected static bool IsShortMidRangeRight(int ix, int jx) {
        double angle = GetAngle(ix-BasketPosition.x,jx-BasketPosition.y);
        return IsShortMidRange(ix, jx) && 45 <= angle && angle <= 90;
    }

    protected static bool IsTwoPointer(int ix, int jx) {
        double distance = GetDistance(ix, jx, BasketPosition.x, BasketPosition.y);
        return (jx < 140 && distance <= 22) || (140 <= jx && distance <= 23.75);
    }

    protected static bool IsThreePointer(int ix, int jx) {
        return !IsTwoPointer(ix, jx);
    }

    protected static bool IsLongMidRange(int ix, int jx) {
        double distance = GetDistance(ix, jx, BasketPosition.x, BasketPosition.y);
        return 8.2 <= distance && ((jx < 140 && distance <= 22) || (140 <= jx && distance <= 23.75));
    }
    protected static bool IsLongMidRangeBaselineLeft(int ix, int jx) {
        return IsLongMidRange(ix, jx) && jx < 85 && ix < 172;
    }

    protected static bool IsLongMidRangeBaselineRight(int ix, int jx) {
        return IsLongMidRange(ix, jx) && jx < 85 && 326 < ix;
    }

    protected static bool IsLongMidRangeBaseline(int ix, int jx) {
        return IsLongMidRange(ix, jx) && jx < 85 && ix < 172 && 326 < ix;
    }

    protected static bool IsLongMidRangeWingLeft(int ix, int jx) {
        return IsLongMidRange(ix, jx) && 85 <= jx && ix < 170;
    }

    protected static bool IsLongMidRangeWingRight(int ix, int jx) {
        return IsLongMidRange(ix, jx) && 85 <= jx && 328 < ix;
    }

    protected static bool IsLongMidRangeCenter(int ix, int jx) {
        return IsLongMidRange(ix, jx) && 170 < ix && ix < 328;
    }

    protected static bool IsLongMidRangeElbowLeft(int ix, int jx) {
        double distance = GetDistance(ix, jx, LeftElbowPosition.x, LeftElbowPosition.y);
        return distance < 3;
    }


    protected static bool IsLongMidRangeElbowRight(int ix, int jx) {
        double distance = GetDistance(ix, jx, RightElbowPosition.x, RightElbowPosition.y);
        return distance < 3;
    }

    protected static bool IsLongMidRangeElbow(int ix, int jx) {
        return IsLongMidRangeElbowLeft(ix, jx) || IsLongMidRangeElbowRight(ix, jx);
    }

    protected static bool IsThreePointerWingLeft(int ix, int jx) {
        return IsThreePointer(ix, jx) && 140 <= jx && ix < 169;
    }

    protected static bool IsThreePointerWingRight(int ix, int jx) {
        return IsThreePointer(ix, jx) && 140 <= jx && 328 < ix;
    }

    protected static bool IsThreePointerCenter(int ix, int jx) {
        return IsThreePointer(ix, jx) && 140 <= jx && 169 < ix && ix < 328;
    }

    protected static bool IsThreePointerHeave(int ix, int jx) {
        return 33 < GetDistance(ix, jx, BasketPosition.x, BasketPosition.y);
    }

    #endregion
}