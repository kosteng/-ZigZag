using UnityEngine;

public class ViewSphere : MonoBehaviour
{
    
    [SerializeField] private float _speed = 1f;
    private bool _direction = false;
    private bool _start = false;
    private int _leftMouseButton = 0;
    public void Move(float deltaTime)
    {

        if (Input.GetMouseButtonDown(_leftMouseButton))
        {
            _start = true;
            _direction = !_direction;
        }

        if (_start && _direction)
        {
            transform.Translate(Vector3.forward * deltaTime * _speed); 
        }

        if (_start && !_direction)
        {
                transform.Translate(Vector3.right * deltaTime * _speed);
        }       
    }
}
