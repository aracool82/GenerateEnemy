using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private float _speed = 5.0f;
    private Vector3 _moveDirection = Vector3.zero;
    
    private void Update()
    {
        Move(_moveDirection);
    }

    private void Move(Vector3 direction)
    {
        transform.Translate(direction * (_speed * Time.deltaTime));
    }

    public void Init(Vector3 moveDirection)
    {
        _moveDirection = moveDirection;
    }
}
