using UnityEngine;

public class ShootBehaviour : MonoBehaviour, IBehaviour
{
    public int ProjectileDamage;

    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private LayerMask _enemyLayerMask;

    [SerializeField] private float _shootCooldown;
    [SerializeField] private float _rotationSpeed;

    private FieldOfView _fow;

    private float _cooldown;

    void Start()
    {
        _fow = GetComponent<FieldOfView>();
    }

    void Update()
    {
        _cooldown -= Time.deltaTime;
    }

    public void Behave()
    {
        RotationHelper.SmoothLookAtTarget(transform, _fow.ClosestTarget(), _rotationSpeed);

        if (_cooldown <= 0f)
        {
            float dstToTarget = Vector3.Distance(_projectileSpawnPoint.position, _fow.ClosestTarget().position);

            if (Physics.Raycast(_projectileSpawnPoint.position, _projectileSpawnPoint.forward, dstToTarget, _enemyLayerMask))
            {
                Shoot();
                _cooldown = _shootCooldown;
            }
        }
    }

    public float Evaluate()
    {
        if (_fow.VisibleTargets.Count > 0)
            return 1f;
        else
            return 0f;
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(_projectile, _projectileSpawnPoint.position, Quaternion.identity);

        HitAction hitAction = projectile.GetComponent<HitAction>();
        hitAction.Damage = ProjectileDamage;

        ProjectileHoming projectileHoming = projectile.GetComponent<ProjectileHoming>();
        projectileHoming.Target = _fow.ClosestTarget();
    }
}