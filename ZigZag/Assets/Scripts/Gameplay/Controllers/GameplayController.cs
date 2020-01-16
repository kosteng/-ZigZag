using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController 
{
    private bool _direction;
    private bool _start;
    private bool _gameOver;
    private const int _leftMouseButton = 0;

    private readonly BallController _ballController;
    private readonly TileController _tileController;
    private readonly UIController _UIController;

    public GameplayController (BallController ballController, 
                               TileController tileController,
                               UIController UIController)
    {
        _ballController = ballController;
        _tileController = tileController;
        _UIController = UIController;
    }

    public void Start()
    {
        _ballController.OnGameOver += GameOver;
    }

    public void GameOver()
    {
        _gameOver = true;
        _ballController.OnGameOver -= GameOver;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(_leftMouseButton))
        {
            _start = true;
            _direction = !_direction;
            _ballController.SetDataGame(_direction, _start);
        }

        if (_gameOver)
        {
            Time.timeScale = 0;
            if (Input.GetMouseButtonDown(_leftMouseButton) && _gameOver)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
