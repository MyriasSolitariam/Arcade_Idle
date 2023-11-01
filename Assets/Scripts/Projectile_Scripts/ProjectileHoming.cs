using UnityEngine;

public class ProjectileHoming : MonoBehaviour
{
    [HideInInspector] public Transform Target;

    [SerializeField] private float _speed;
    [SerializeField] private float _yAxisOffset;

    private Rigidbody _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Target == null || Target.GetComponent<HealthProperty>().IsDead)
        {
            Destroy(gameObject);
            return;
        }

        FollowTarget(Target, _speed);
    }

    private void FollowTarget(Transform target, float speed)
    {
        Vector3 adjustedPosition = new Vector3(target.position.x, target.position.y + _yAxisOffset, target.position.z);

        transform.LookAt(adjustedPosition);

        _rb.velocity = transform.forward * speed;
    }
}
