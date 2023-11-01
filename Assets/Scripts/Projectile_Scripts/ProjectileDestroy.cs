using UnityEngine;

public class ProjectileDestroy : MonoBehaviour
{
    [SerializeField] private float _destroyTimer;
    
    private HitAction _hitAction;
    
    private float _timer;
    
    void Awake()
    {
        _hitAction = GetComponent<HitAction>();
        _timer = _destroyTimer;
    }
    
    void Update()
    {
        _timer -= Time.deltaTime;
        
        if (_timer < 0f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(_hitAction.TargetTag))
        {
            Destroy(gameObject);
        }
    }
}
