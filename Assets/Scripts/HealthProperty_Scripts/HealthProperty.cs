using UnityEngine;

public class HealthProperty : MonoBehaviour
{
    public float Health;
    [HideInInspector] public bool IsDead;
    [HideInInspector] public float CurrentHealth;

    private Animator _anim;

    private int _animIDDead;

    void Awake()
    {
        _anim = GetComponent<Animator>();

        CurrentHealth = Health;
        _animIDDead = Animator.StringToHash("Dead");
    }

    void Update()
    {
        if (!IsDead)
        {
            if (CurrentHealth <= 0f)
            {
                OnDeath();
            }
        }
    }

    private void OnDeath()
    {
        _anim.SetTrigger(_animIDDead);
        IsDead = true;
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
