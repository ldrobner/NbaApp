namespace NbaApp.Core.Types.ShotChart;

public class ShotChartImage : ShotChartCollection {
    private readonly int _width = 500;
    private readonly int _height = 472;

    public ShotChartFragmentPixel[,] Matrix { get => _matrix; }
    private readonly ShotChartFragmentPixel[,] _matrix;

    public ShotChartImage() : base() {
        _matrix = new ShotChartFragmentPixel[_width,_height];

        for(int ix = 0; ix < _width; ix++) {
            for(int jx = 0; jx < _height; jx ++) {
                int pixelPoints = IsTwoPointer(ix, jx) ? 2 : 3;
                _matrix[ix,jx] = new ShotChartFragmentPixel(pixelPoints, ix, jx);
            }
        }
    }

    public override void Update(Shot update)
    {
        ShotChartFragmentPixel scFrag = _matrix[update.Left,update.Top];
        Update(scFrag);
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
}