using UnityEngine;
using UnityEngine.AI;

public class MoveBehaviour : MonoBehaviour, IBehaviour
{
    public Transform DefaultTarget;
    
    public float _rotationSpeed = 240f;
    
    private FieldOfView _fow;
    private NavMeshAgent _agent;
    private Animator _anim;
    
    private int _animIDSpeed;
    private float _animationBlend;
    
    private Transform _currentTarget;

    void Start()
    {
        _fow = GetComponent<FieldOfView>();
        _agent = GetComponentInChildren<NavMeshAgent>();
        _anim = GetComponent<Animator>();

        if (DefaultTarget == null) DefaultTarget = transform;

        _currentTarget = SetCurrentTarget();

        _animIDSpeed = Animator.StringToHash("Speed");
    }

    void Update()
    {
        _currentTarget = SetCurrentTarget();

        RotationHelper.SmoothLookAtTarget(transform, _currentTarget, _rotationSpeed);
        SetAnimationBlend();
    }
    
    public void Behave()
    {
        _agent.SetDestination(_currentTarget.position);
    }

    public float Evaluate()
    {
        float _dst = Vector3.Distance(_currentTarget.position, transform.position);

        if (_dst <= _agent.stoppingDistance)
        {
            // if enemy is close enough to his target, he doesn't want to move anymore
            _agent.ResetPath();
            return 0f;
        }
        else
        {
            // enemy isn't close enough to his target, he wants to move towards it
            return 1f;
        }
    }

    private Transform SetCurrentTarget()
    {
        Transform target;

        // if enemy sees player or base, he changes his target to it        
        if (_fow.VisibleTargets.Count > 0)
        {
            target = _fow.ClosestTarget();
        }
        // default enemy target
        else
        {
            target = DefaultTarget;
        }

        return target;
    }
    
    void SetAnimationBlend()
    {
        _animationBlend = Mathf.Lerp(_animationBlend, _agent.velocity.magnitude, Time.deltaTime * _agent.acceleration);
        if (_animationBlend < 0.01f) _animationBlend = 0f;

        _anim.SetFloat(_animIDSpeed, _animationBlend);
    }
}
