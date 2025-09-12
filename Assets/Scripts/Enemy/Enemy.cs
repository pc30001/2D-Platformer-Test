using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private WayPoint[] _wayPoints;
    [SerializeField] private float _speedX = 1;

    private Rigidbody2D _rigibody;
    private bool _isTurnRight = true;
    private int _wayPointIndex;
    private Transform _target;
    private float _maxSqrDistance = 0.01f;

    private void Start()
    {
        _rigibody = GetComponent<Rigidbody2D>();
        _target = _wayPoints[_wayPointIndex].transform;
    }

    private void FixedUpdate()
    {
        Move();

        if (IsTargetReached())
            ChangeTarget();
    }

    private void Move()
    {
        Vector2 newPosotion = Vector2.MoveTowards(transform.position, _target.position, _speedX * Time.fixedDeltaTime);
        _rigibody.MovePosition(newPosotion);

    }

    private bool IsTargetReached()
    {
        float sqrDistance = (transform.position - _target.position).sqrMagnitude;

        return sqrDistance < _maxSqrDistance;
    }

    private void ChangeTarget()
    {
        _wayPointIndex = ++_wayPointIndex % _wayPoints.Length;
        _target = _wayPoints[_wayPointIndex].transform;

        // Поворот персонажа
        if ((transform.position.x < _target.position.x && _isTurnRight == false) 
            || (transform.position.x > transform.position.x && _isTurnRight))
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isTurnRight = !_isTurnRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
