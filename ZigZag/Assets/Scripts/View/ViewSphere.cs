using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewSphere : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    public void Move (float deltaTime)
    {
        transform.Translate(Vector3.forward * deltaTime*_speed);
    }
}
