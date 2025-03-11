namespace NbaApp.Core.Types.ShotChart;

public class ShotChart {
    private readonly int _width = 500;
    private readonly int _height = 472;
    private readonly ShotChartFragmentPixel[,] _matrix;
    public List<Shot> Shots { get => _shots; }
    private List<Shot> _shots;
    
    private readonly int _makes;

    #region Constants

    private static int[] BasketPosition = new int[2]{250, 55};
    private static int[] LeftElbowPosition = new int[2]{170, 190};
    private static int[] RightElbowPosition = new int[2]{328, 190};

    #endregion

    public ShotChart() {
        _makes = 0;

        _shots = new List<Shot>();
        _matrix = new ShotChartFragmentPixel[_width,_height];

        for(int ix = 0; ix < _width; ix++) {
            for(int jx = 0; jx < _height; jx ++) {
                int pixelPoints = IsTwoPointer(ix, jx) ? 2 : 3;
                _matrix[ix,jx] = new ShotChartFragmentPixel(pixelPoints, ix, jx);
            }
        }
    }

    #region Zone Finders

    private static Boolean IsLeftCornerThree(int ix, int jx) {
        return 0 <= ix && ix < 30 && 0 <= jx && jx <= 140;
    }

    private static Boolean IsRightCornerThree(int ix, int jx) {
        return 469 < ix && ix <= 500 && 0 <= jx && jx <= 140;
    }

    private static Boolean IsCornerThree(int ix, int jx) {
        return IsLeftCornerThree(ix, jx) || IsRightCornerThree(ix, jx);
    }

    private static Boolean IsLayupOrDunk(int ix, int jx) {
        double distance = GetDistance(ix, jx, BasketPosition[0], BasketPosition[1]);
        return distance <= 3;
    }

    private static Boolean IsShortMidRange(int ix, int jx) {
        double distance = GetDistance(ix, jx, BasketPosition[0], BasketPosition[1]);
        return 3 < distance && distance < 8.2;
    }

    private static Boolean IsShortMidRangeLeft(int ix, int jx) {
        double angle = 180 / Math.PI * Math.Atan((ix-BasketPosition[0])/(jx-BasketPosition[1]));
        return IsShortMidRange(ix, jx) && -90 <= angle && angle <= -45;
    }

    private static Boolean IsShortMidRangeCenter(int ix, int jx) {
        double angle = 180 / Math.PI * Math.Atan((ix-BasketPosition[0])/(jx-BasketPosition[1]));
        return IsShortMidRange(ix, jx) && -45 < angle && angle < 45;
    }

    private static Boolean IsShortMidRangeRight(int ix, int jx) {
        double angle = 180 / Math.PI * Math.Atan((ix-BasketPosition[0])/(jx-BasketPosition[1]));
        return IsShortMidRange(ix, jx) && 45 <= angle && angle <= 90;
    }

    private static Boolean IsTwoPointer(int ix, int jx) {
        double distance = GetDistance(ix, jx, BasketPosition[0], BasketPosition[1]);
        return (jx < 140 && distance <= 22) || (140 <= jx && distance <= 23.75);
    }

    private static Boolean IsThreePointer(int ix, int jx) {
        return !IsTwoPointer(ix, jx);
    }

    private static Boolean IsLongMidRange(int ix, int jx) {
        double distance = GetDistance(ix, jx, BasketPosition[0], BasketPosition[1]);
        return 8.2 <= distance && ((jx < 140 && distance <= 22) || (140 <= jx && distance <= 23.75));
    }
    private static Boolean IsLongMidRangeBaselineLeft(int ix, int jx) {
        return IsLongMidRange(ix, jx) && jx < 85 && ix < 172;
    }

    private static Boolean IsLongMidRangeBaselineRight(int ix, int jx) {
        return IsLongMidRange(ix, jx) && jx < 85 && 326 < ix;
    }

    private static Boolean IsLongMidRangeBaseline(int ix, int jx) {
        return IsLongMidRange(ix, jx) && jx < 85 && ix < 172 && 326 < ix;
    }

    private static Boolean IsLongMidRangeWingLeft(int ix, int jx) {
        return IsLongMidRange(ix, jx) && 85 <= jx && ix < 170;
    }

    private static Boolean IsLongMidRangeWingRight(int ix, int jx) {
        return IsLongMidRange(ix, jx) && 85 <= jx && 328 < ix;
    }

    private static Boolean IsLongMidRangeCenter(int ix, int jx) {
        return IsLongMidRange(ix, jx) && 170 < ix && ix < 328;
    }

    private static Boolean IsLongMidRangeElbowLeft(int ix, int jx) {
        double distance = GetDistance(ix, jx, LeftElbowPosition[0], LeftElbowPosition[1]);
        return distance < 3;
    }


    private static Boolean IsLongMidRangeElbowRight(int ix, int jx) {
        double distance = GetDistance(ix, jx, RightElbowPosition[0], RightElbowPosition[1]);
        return distance < 3;
    }

    private static Boolean IsLongMidRangeElbow(int ix, int jx) {
        return IsLongMidRangeElbowLeft(ix, jx) || IsLongMidRangeElbowRight(ix, jx);
    }

    private static Boolean IsThreePointerWingLeft(int ix, int jx) {
        return IsThreePointer(ix, jx) && 140 <= jx && ix < 169;
    }

    private static Boolean IsThreePointerWingRight(int ix, int jx) {
        return IsThreePointer(ix, jx) && 140 <= jx && 328 < ix;
    }

    private static Boolean IsThreePointerCenter(int ix, int jx) {
        return IsThreePointer(ix, jx) && 140 <= jx && 169 < ix && ix < 328;
    }

    private static Boolean IsLongThreePointerOrHeave(int ix, int jx) {
        return 33 < GetDistance(ix, jx, BasketPosition[0], BasketPosition[1]);
    }


    #endregion

    private static double GetDistance(int x1, int y1, int x2, int y2) {
        return Math.Sqrt(
            Math.Pow(x1-x2,2) + Math.Pow(y1-y2,2)
        ) / 10;
    }

    private static double GetWeight(double distance) {
        return 1 - Math.Abs(distance/50);
    }

    private void Update(ShotChartFragmentPixel root) {
        // init
        int rootHash = root.GetHashCode();
        HashSet<ShotChartFragmentPixel> visited = new HashSet<ShotChartFragmentPixel>{ root };
        Queue<ShotChartFragmentPixel> q = new Queue<ShotChartFragmentPixel>();
        q.Enqueue(root);
        
        // BFS
        while(q.Count != 0) {
            ShotChartFragmentPixel node = q.Dequeue();
            if(!visited.Contains(node)) {
                visited.Add(node);

                // Get all adjacent nodes
                for(int d_ix = -1; d_ix < 2; d_ix++) {
                    for(int d_jx = -1; d_jx < 2; d_jx++) {
                        int newIx = node.Ix + d_ix;
                        int newJx = node.Jx + d_jx;

                        if(0 <= newIx && newIx < _width && 0 <= newJx && newJx < _height) { // if in bounds
                            double distance = GetDistance(root.Ix, root.Jx, newIx, newJx);

                            if(distance < 5) { // if within 5ft
                                // update weights
                                double weight = GetWeight(distance);
                                root.UpdateWeightedValues( node.GetHashCode(), node.Attempts * weight );
                                node.UpdateWeightedValues( rootHash, root.Attempts * weight );
                                q.Enqueue(_matrix[newIx,newJx]); // check next node
                            }
                        }
                    }
                }
            }
        }
    }

    public void AddShot(Shot shot) {
        _shots.Add(shot);

        // gather stats
        

        // Shot Chart Matrix
        ShotChartFragmentPixel scFrag = _matrix[shot.Left,shot.Top];
        scFrag.Attempts += 1;
        scFrag.Makes += shot.Make ? 1 : 0;
        scFrag.Assisteds += shot.Assisted ? 1 : 0;
        Update(scFrag);
    }
}