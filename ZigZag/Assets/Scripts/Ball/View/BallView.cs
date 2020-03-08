using System;
using UnityEngine;

public class BallView : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    private const float BallStartPosition = 2f;
    public event Action OnBallFall;
    public event Action OnCollisionCoin;
    

    public void OnUpdate()
    {
        if (!Physics.Raycast(transform.position, Vector3.down, 4f))
        {
            OnBallFall?.Invoke();
        }
    }

    public void OnStart()
    {
        transform.position = new Vector3(0, BallStartPosition, 0);
    }

    public void Move(float deltaTime, bool isForward, bool start)
    {
        if (start && isForward)      
            transform.Translate(Vector3.forward * deltaTime * _speed);      
        if (start && !isForward)       
            transform.Translate(Vector3.right * deltaTime * _speed);     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);
            OnCollisionCoin?.Invoke();
        }
    }
}
