using UnityEngine;

[RequireComponent(typeof(InputReader), typeof(GroudDetector), typeof(PlayerMover))]
[RequireComponent(typeof(PlayerAnimator))]
public class Player : MonoBehaviour
{
    private InputReader _inputReader;
    private PlayerMover _mover;
    private GroudDetector _groudDetector;
    private PlayerAnimator _animator;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _groudDetector = GetComponent<GroudDetector>();
        _mover = GetComponent<PlayerMover>();
        _animator = GetComponent<PlayerAnimator>();
    }

    private void FixedUpdate()
    {
        float horizontal = _inputReader.Direction;
        float vertical = _inputReader.VerticalDirection;

        _animator.SetSpeedX(horizontal);

        if (horizontal != 0 || vertical != 0)
        {
            _mover.Move(horizontal, vertical);
        }

        if (_inputReader.GetIsJump() && _groudDetector.IsGround)
        {
            _mover.Jump();
        }
    }
}
