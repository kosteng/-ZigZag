﻿using System;
using UnityEngine;

public class BallView : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    public bool gameOver = false;
    public event Action OnGameOver;
    public event Action OnCollisionCoin;

    public void OnUpdate()
    {
        if (!Physics.Raycast(transform.position, Vector3.down, 4f))
        {
            gameOver = true;
            OnGameOver?.Invoke();
        }
    }

    public void OnStart()
    {
        transform.position = new Vector3(0, 1.9125f, 0);
        gameOver = false;
        Time.timeScale = 1;
    }

    public void Move(float deltaTime, bool direction, bool start)
    {
        if (start && direction)
        {
            transform.Translate(Vector3.forward * deltaTime * _speed);
        }

        if (start && !direction)
        {
            transform.Translate(Vector3.right * deltaTime * _speed);
        }
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
