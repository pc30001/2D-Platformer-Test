using UnityEngine;

[RequireComponent(typeof(InputReader), typeof(GroudDetector), typeof(PlayerMover))]
[RequireComponent(typeof(PlayerAnimator), typeof(CollisionHandler), typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    private InputReader _inputReader;
    private PlayerMover _mover;
    private GroudDetector _groudDetector;
    private PlayerAnimator _animator;
    private CollisionHandler _collisionHandler;
    private IInteractable _interactable;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _groudDetector = GetComponent<GroudDetector>();
        _mover = GetComponent<PlayerMover>();
        _animator = GetComponent<PlayerAnimator>();
        _collisionHandler = GetComponent<CollisionHandler>();
    }

    private void OnEnable()
    {
        _collisionHandler.FinishReached += OnFinishReached;
    }

    private void OnDisable()
    {
        _collisionHandler.FinishReached -= OnFinishReached;
    }

    private void FixedUpdate()
    {
        //float horizontal = _inputReader.Direction;
        //float vertical = _inputReader.VerticalDirection;

        //_animator.SetSpeedX(horizontal);

        //if (horizontal != 0 || vertical != 0)
        //{
        //    _mover.Move(horizontal, vertical);
        //}

        //if (_inputReader.GetIsJump() && _groudDetector.IsGround)
        //{
        //    _mover.Jump();
        //}
        _animator.SetSpeedX(_inputReader.Direction);

        if (_inputReader.Direction != 0)
        {
           // _mover.Move(_inputReader.Direction);
        //    _fliper.LookAtTarget(transform.position + Vector3.right * _inputReader.Direction);
        }

        if (_inputReader.GetIsJump() && _groudDetector.IsGround)
            _mover.Jump();

        if (_inputReader.GetIsInteract() && _interactable != null)
            _interactable.Interact();
    }

    private void OnFinishReached(IInteractable interactable)
    {
        _interactable = interactable;
    }
}
