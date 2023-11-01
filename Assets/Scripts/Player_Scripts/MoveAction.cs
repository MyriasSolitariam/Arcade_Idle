using UnityEngine;

public class MoveAction : MonoBehaviour
{
    [SerializeField] private bool _inControl;

    [Header("Player")]
    [Tooltip("Move speed of the character in m/s")]
    public float MoveSpeed = 10f;

    [Tooltip("Acceleration and deceleration")]
    public float SpeedChangeRate = 20f;

    [Tooltip("How fast the character turns to face movement direction")]
    [Range(0.0f, 0.3f)]
    public float RotationSmoothTime = 0.12f;

    [Tooltip("The character uses its own gravity value. The engine default is -9.81f")]
    public float Gravity = -15.0f;
    
    [Header("Player Grounded")]
    [Tooltip("If the character is grounded or not. Not part of the CharacterController built in grounded check")]
    public bool Grounded = true;

    [Tooltip("Useful for rough ground")]
    public float GroundedOffset = -0.14f;

    [Tooltip("The radius of the grounded check. Should match the radius of the CharacterController")]
    public float GroundedRadius = 0.28f;

    [Tooltip("What layers the character uses as ground")]
    public LayerMask GroundLayers;

    private PlayerControlsInputs _input;
    private CharacterController _controller;
    private Animator _animator;

    // player
    private float _speed;
    private float _rotationVelocity;
    private float _targetRotation;
    private float _animationBlend;
    private float _verticalVelocity;
    private float _terminalVelocity = 53.0f;

    // animation IDs
    private int _animIDSpeed;
    private int _animIDMotionSpeed;
    
    void Awake()
    {
        _input = GetComponent<PlayerControlsInputs>();
        _controller = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator>();

        AssignAnimationIDs();
    }

    void Update()
    {
        if (_inControl)
        {
            ApplyGravity();
            GroundedCheck();
            Move();
        }
    }

    private void AssignAnimationIDs()
    {
        _animIDSpeed = Animator.StringToHash("Speed");
        _animIDMotionSpeed = Animator.StringToHash("MotionSpeed");
    }

    private void GroundedCheck()
    {
        // set sphere position, with offset
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset,
            transform.position.z);
        Grounded = Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayers,
            QueryTriggerInteraction.Ignore);
    }

    private void Move()
    {
        // set target speed based on move speed
        float targetSpeed = MoveSpeed;

        // if there is no input, set the target speed to 0
        if (_input.MoveInput == Vector2.zero) targetSpeed = 0.0f;

        // a reference to the players current horizontal velocity
        float currentHorizontalSpeed = new Vector3(_controller.velocity.x, 0.0f, _controller.velocity.z).magnitude;

        float speedOffset = 0.1f;
        float inputMagnitude = _input.AnalogMovement ? _input.MoveInput.magnitude : 1f;

        // accelerate or decelerate to target speed
        if (currentHorizontalSpeed < targetSpeed - speedOffset ||
            currentHorizontalSpeed > targetSpeed + speedOffset)
        {
            // creates curved result rather than a linear one giving a more organic speed change
            // note T in Lerp is clamped, so we don't need to clamp our speed
            _speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude,
                Time.deltaTime * SpeedChangeRate);

            // round speed to 3 decimal places
            _speed = Mathf.Round(_speed * 1000f) / 1000f;
        }
        else
        {
            _speed = targetSpeed;
        }

        _animationBlend = Mathf.Lerp(_animationBlend, targetSpeed, Time.deltaTime * SpeedChangeRate);
        if (_animationBlend < 0.01f) _animationBlend = 0f;

        // normalise input direction
        Vector3 inputDir = new Vector3(_input.MoveInput.x, 0.0f, _input.MoveInput.y).normalized;

        // if there is a move input rotate player when the player is moving
        if (_input.MoveInput != Vector2.zero)
        {
            _targetRotation = Mathf.Atan2(inputDir.x, inputDir.z) * Mathf.Rad2Deg;
            //_mainCamera.transform.eulerAngles.y;
            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity,
                RotationSmoothTime);
            
            // rotate to face input direction
            transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
        }
        

        Vector3 targetDir = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;

        // move the player
        _controller.Move(targetDir.normalized * (_speed * Time.deltaTime) +
                             new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);

        // update animator
        _animator.SetFloat(_animIDSpeed, _animationBlend);
        _animator.SetFloat(_animIDMotionSpeed, inputMagnitude);
    }

    private void ApplyGravity()
    {
        if (Grounded)
        {
            // stop our velocity dropping infinitely when grounded
            if (_verticalVelocity < 0.0f)
            {
                _verticalVelocity = -2f;
            }
        }

        if (_verticalVelocity < _terminalVelocity)
        {
            _verticalVelocity += Gravity * Time.deltaTime;
        }
    }
}
