using System;

public class BallController 
{
    private readonly BallView _ballView;
    private bool _direction;
    private bool _start;
    public int collectedCoinCount = 0;
    public event Action OnBallFall;

    public BallController(BallView ballView)
    {
        _ballView = ballView;
    }

    public void Start()
    {
        _ballView.OnStart();
        _ballView.OnBallFall+= BallFall;
        _ballView.OnCollisionCoin += CoinCollect;
    }

    public void BallFall ()
    {
        OnBallFall?.Invoke();
        _ballView.OnBallFall -= BallFall;
    }
    public void Update(float deltaTime)
    {
        _ballView.OnUpdate();
        _ballView.Move(deltaTime, _direction, _start);
    }

    public void SetDataGame (bool direction, bool start)
    {
        _direction = direction;
        _start = start;
    }

    public void CoinCollect()
    {
        collectedCoinCount++;
    }
}
