using UnityEngine;

public abstract class OnDeadEvent : MonoBehaviour
{
    public delegate void DeadCallback();
    public DeadCallback OnDead;

    protected HealthProperty _health;

    protected bool _deathTracked = false;
    
    void Update()
    {
        if (_deathTracked) return;
        
        if (_health.IsDead)
        {
            OnDead();
            _deathTracked = true;
        }
    }
}
