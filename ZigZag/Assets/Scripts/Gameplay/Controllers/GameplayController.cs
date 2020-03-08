using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController 
{
    private bool _directionMove;
    private bool _startGame;
    private bool _gameOver;
    private const int LeftMouseButton = 0;

    private readonly BallController _ballController;
    private readonly UIController _UIController;

    public GameplayController (BallController ballController, UIController UIController)
    {
        _ballController = ballController;
        _UIController = UIController;
    }

    public void Start()
    {
        _ballController.OnBallFall += GameOver;
        _UIController.ShowTapToPlayText(true);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        _gameOver = true;
        _UIController.GameOver();
        _ballController.OnBallFall -= GameOver;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            if (!_startGame)
            {             
                _startGame = true;
                _UIController.ShowTapToPlayText(false);
            }
            _directionMove = !_directionMove;
            _ballController.SetDataGame(_directionMove, _startGame);
        }

        if (_gameOver)
        {
            Restart();
        }
        _UIController.UpdateCoin(_ballController.collectedCoinCount);
    }

    private void Restart()
    {
        Time.timeScale = 0;
        if (Input.GetMouseButtonDown(LeftMouseButton) && _gameOver)
        {
            SceneManager.LoadScene(0);
        }
    }
}
