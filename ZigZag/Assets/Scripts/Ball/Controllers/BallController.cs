using System;

public class BallController 
{
    private readonly BallView _ballView;
    private bool _direction;
    private bool _start;
    public int collectedCoinCount = 0;
    public event Action OnGameOver;

    public BallController(BallView ballView)
    {
        _ballView = ballView;
    }

    public void Start()
    {
        _ballView.OnStart();
        _ballView.OnGameOver += GameOver;
        _ballView.OnCollisionCoin += CoinCollect;
    }

    public void GameOver ()
    {
        OnGameOver?.Invoke();
        _ballView.OnGameOver -= GameOver;
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
