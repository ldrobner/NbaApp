using ZstdSharp.Unsafe;

namespace NbaApp.Core.Types;

public class ShotChart {
    private readonly int _width = 500;
    private readonly int _height = 472;
    private readonly ShotChartFragment[,] _matrix;

    public List<Shot> Shots { get => _shots; }
    private List<Shot> _shots;

    public ShotChart() {
        _shots = new List<Shot>();
        _matrix = new ShotChartFragment[_width,_height];
        
        for(int ix = 0; ix < _width; ix++) {
            for(int jx = 0; jx < _height; jx ++) {
                if(
                    (jx <= 140 && (ix < 31 || 469 < ix)) || 
                    (jx > 140 && GetDistance(ix, jx, 250, 55) > 23.75)
                ) {
                    _matrix[ix,jx] = new ShotChartFragment(3, ix, jx);
                } else {
                    _matrix[ix,jx] = new ShotChartFragment(2, ix, jx);
                }
            }
        }
    }

    private static double GetDistance(int x1, int y1, int x2, int y2) {
        return Math.Sqrt(
            Math.Pow(x1-x2,2) + Math.Pow(y1-y2,2)
        ) / 10;
    }

    private static double GetWeight(double distance) {
        return 1 - Math.Abs(distance/50);
    }

    private void Update(ShotChartFragment root) {
        // init
        int rootHash = root.GetHashCode();
        HashSet<ShotChartFragment> visited = new HashSet<ShotChartFragment>{ root };
        Queue<ShotChartFragment> q = new Queue<ShotChartFragment>();
        q.Enqueue(root);
        
        // BFS
        while(q.Count != 0) {
            ShotChartFragment node = q.Dequeue();
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
        ShotChartFragment scFrag = _matrix[shot.Left,shot.Top];

        scFrag.Attempts += 1;
        scFrag.Makes += shot.Make ? 1 : 0;
        scFrag.Assisteds += shot.Assisted ? 1 : 0;

        Update(scFrag);
    }
}