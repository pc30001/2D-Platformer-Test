using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void SetSpeedX(float speedX)
    {
        _animator.SetFloat(ConstantsData.AnimatorParameters.SpeedX, speedX);
    }

    public void SetSpeedY(float speedY)
    {
        _animator.SetFloat(ConstantsData.AnimatorParameters.SpeedY, Mathf.Abs(speedY));
    }
}
