using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimatorController : MonoBehaviour
{
    [SerializeField] private InputActionReference _jumpAction;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private float _animationSmoothTime = 0.75f;

    private int _speedHash = Animator.StringToHash("Speed");
    private float _currentAnimationSpeed = 0f;
    private float _speedVelocity = 0f;

    void Update()
    {
        _currentAnimationSpeed = Mathf.SmoothDamp(_currentAnimationSpeed, _playerMovement._usedSpeed, ref _speedVelocity, _animationSmoothTime);
        _animator.SetFloat(_speedHash, _currentAnimationSpeed);
        _animator.SetBool("Glide", _playerMovement._isGliding);

        if (_jumpAction.action.WasPerformedThisFrame() && !_playerMovement._isGrounded && !_playerMovement._isGliding)
        {
            _animator.SetTrigger("Jump");
        }
    }
}
