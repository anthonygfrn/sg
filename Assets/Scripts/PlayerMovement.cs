using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Transform _orientation;
    [SerializeField] private Transform _body;
    [SerializeField] private GameObject _sunLight;
    public PlayerState _playerState { get; private set; } = PlayerState.WALK;

    [Header("Settings")]
    [SerializeField] private float _normalMovementSpeed = 3f;
    [SerializeField] private float _slowMovementSpeed = 1.5f;
    [SerializeField] private float _runMovementSpeed = 6f;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundCheckDistance = 0.2f;
    [SerializeField] private float _glideGravityMultiplier = 1f;
    [SerializeField] private float _glideFallSpeed = -2f;

    private Vector2 _moveDirection;
    public float _usedSpeed { get; private set; } = 0f;
    public bool _isGrounded { get; private set; } = true;
    public bool _isFalling { get; private set; } = false;
    public bool _isGliding { get; private set; } = false;
    private bool _isRunning = false;

    private void Update()
    {
        // Check if player is grounded
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, _groundCheckDistance, _groundLayer);
        _isFalling = !_isGrounded && (_rb.velocity.y <= 0);

        if (_isGrounded && _isGliding) _isGliding = false;

        // Determine player state based on input and grounded status
        UpdatePlayerState();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Climbable"))
        {

        }
    }

    private void UpdatePlayerState()
    {
        if (_moveDirection.magnitude > 0.1f)
        {
            if (_isRunning && !_isGliding && !_isFalling)
            {
                _playerState = PlayerState.RUN;
            }
            else if (!_isGliding && !_isFalling)
            {
                _playerState = PlayerState.WALK;
            }
        }
        else
        {
            _playerState = PlayerState.IDLE;
        }
    }

    void FixedUpdate()
    {
        switch (_playerState)
        {
            case PlayerState.WALK:
                _usedSpeed = _sunLight.activeSelf == true ? _slowMovementSpeed : _normalMovementSpeed;
                break;

            case PlayerState.RUN:
                _usedSpeed = _runMovementSpeed;
                break;

            default:
                _usedSpeed = _playerState == PlayerState.IDLE ? 0f : _normalMovementSpeed;
                break;
        }

        // Base movement
        Vector3 move = _orientation.forward * _moveDirection.y + _orientation.right * _moveDirection.x;
        Vector3 velocity = move.normalized * _usedSpeed;

        // Apply glide if active
        if (_isGliding && !_isGrounded)
        {
            Vector3 glideDirection = _body.forward;
            float glideSpeed = _runMovementSpeed * 1f;

            float newY = Mathf.Max(_rb.velocity.y * _glideGravityMultiplier, _glideFallSpeed);
            _rb.velocity = new Vector3(glideDirection.x * glideSpeed, newY, glideDirection.z * glideSpeed);
        }
        else
        {
            _rb.velocity = new Vector3(velocity.x, _rb.velocity.y, velocity.z);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveDirection = context.ReadValue<Vector2>();
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (_sunLight.activeSelf == true) return;

        // Set running state based on whether Shift key is being held down
        if (context.performed || context.started)
        {
            _isRunning = true;
        }
        else if (context.canceled)
        {
            _isRunning = false;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // Only allow jumping when grounded
        if (context.performed && _isGrounded)
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isGrounded = false;
        }
        else if (context.performed && !_isGrounded && !_isGliding)
        {
            _isGliding = true;
        }
        else if (context.performed && _isGliding)
        {
            _isGliding = false;
        }
    }
}

public enum PlayerState
{
    IDLE,
    WALK,
    RUN,
    SLOWWALK,
    JUMP,
}