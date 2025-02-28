namespace NbaApp.Core.Types;

public class Play {
    private string _type;
    public string Type { get => _type; set => _type = value; }

    private float _clock;
    public float Clock { get => _clock; set => _clock = value; }

    private int _quarter;
    public int Quarter { get => _quarter; set => _quarter = value; }

    private string _actor;
    public string Actor { get => _actor; set => _actor = value; }

    private string _secondaryActor;
    public string SecondaryActor { get => _secondaryActor; set => _secondaryActor = value; }

    private bool _isJumpshot;
    public bool IsJumpshot { get => _isJumpshot; set => _isJumpshot = value; }

    private bool _isDunk;
    public bool IsDunk { get => _isDunk; set => _isDunk = value; }

    private bool _isLayup;
    public bool IsLayup { get => _isLayup; set => _isLayup = value; }

    private bool _madeShot;
    public bool MadeShot { get => _madeShot; set => _madeShot = value; }

    private int _shotDistance;
    public int ShotDistance { get => _shotDistance; set => _shotDistance = value; }

    private bool _assisted;
    public bool Assisted { get => _assisted; set => _assisted = value; }

    private bool _deadBall;
    public bool DeadBall { get => _deadBall; set => _deadBall = value; }

    public Play(
        string type,
        float clock, int quarter,
        string actor, string secondaryActor,
        bool isJumpshot, bool isDunk, bool isLayup, bool madeShot,
        int shotDistance,
        bool assisted,
        bool deadBall
    ) {
        _type = type;
        _clock = clock;
        _quarter = quarter;
        _actor = actor;
        _secondaryActor = secondaryActor;
        _isJumpshot = isJumpshot;
        _isDunk = isDunk;
        _isLayup = isLayup;
        _madeShot = madeShot;
        _shotDistance = shotDistance;
        _assisted = assisted;
        _deadBall = deadBall;
    }
}