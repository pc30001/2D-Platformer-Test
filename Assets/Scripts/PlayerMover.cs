using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    private const float SPEED_COEFFICIENT = 50;
    private const string VerticalAxis = "Vertical";

    [SerializeField] private float _speedX = 1;
    [SerializeField] private float _speedY = 1; // Добавлено
    [SerializeField] private float _jumpForce = 500;

    private Rigidbody2D _rigibody;
    private bool _isTurnRight = true;
    private float _directiony;

    private void Start()
    {
        _rigibody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float directionX = Input.GetAxis("Horizontal");
        float directionY = Input.GetAxis("Vertical");

        Move(directionX, directionY);
    }

    public void Jump()
    {
        _rigibody.AddForce(new Vector2(0, _jumpForce));
       // _directiony = Input.GetAxis(VerticalAxis);
    }

    public void Move(float directionX, float directionY)
    {
        _rigibody.velocity = new Vector2(
            _speedX * directionX * SPEED_COEFFICIENT * Time.fixedDeltaTime,
            _speedY * directionY * SPEED_COEFFICIENT * Time.fixedDeltaTime
        );

        // Поворот персонажа
        if ((directionX > 0 && !_isTurnRight) || (directionX < 0 && _isTurnRight))
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