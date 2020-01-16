using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController 
{
    private readonly BallView _ballView;
    private bool _direction;
    private bool _start;
    public event Action OnGameOver;

    public BallController(BallView ballView)
    {
        _ballView = ballView;
    }

    public void Start()
    {
        _ballView.Start();
        _ballView.OnGameOver += GameOver;
    }

    public void GameOver ()
    {
        OnGameOver?.Invoke();
        _ballView.OnGameOver -= GameOver;
    }
    public void Update(float deltaTime)
    {
        _ballView.Update();
        _ballView.Move(deltaTime, _direction, _start);
    }

    public void SetDataGame (bool direction, bool start)
    {
        _direction = direction;
        _start = start;
    }
}
