using UnityEngine;
using UnityEngine.SceneManagement;

public class BallView : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    private bool _direction = false;
    private int _leftMouseButton = 0;
    public bool start = false;
    public bool gameOver = false;
    public int collectedCoinCount = 0;

    public void Update()
    {
        if (!Physics.Raycast(transform.position, Vector3.down, 4f))
        {
            gameOver = true;
        }
    }

    public void Start()
    {
        transform.position = new Vector3(0, 1.9125f, 0);
        _direction = false;
        start = false;
        gameOver = false;
        Time.timeScale = 1;
    }

    public void Move(float deltaTime)
    {

        if (Input.GetMouseButtonDown(_leftMouseButton))
        {
            start = true;
            _direction = !_direction;
        }

        if (start && _direction)
        {
            transform.Translate(Vector3.forward * deltaTime * _speed);
        }

        if (start && !_direction)
        {
            transform.Translate(Vector3.right * deltaTime * _speed);
        }
        if (gameOver)
        {
            Time.timeScale = 0;
            if (Input.GetMouseButtonDown(_leftMouseButton) && gameOver)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);
            collectedCoinCount++;
        }
    }
}
