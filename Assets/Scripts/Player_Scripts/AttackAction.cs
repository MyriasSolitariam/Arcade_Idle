using UnityEngine;

public class AttackAction : MonoBehaviour
{
    public float AttackCooldown = 0.4f;
    
    private PlayerControlsInputs _input;
    private Animator _anim;
    
    private int _animIDAttack;

    private float _cooldown = float.MinValue;

    void Awake()
    {
        _input = GetComponent<PlayerControlsInputs>();
        _anim = GetComponent<Animator>();

        _animIDAttack = Animator.StringToHash("Attack");
    }

    void Update()
    {
        _cooldown -= Time.deltaTime;

        if (_input.AttackInput > 0f)
        {
            if (_cooldown <= 0f)
            {
                Attack();
            }
        }
    }

    private void Attack()
    {
        _anim.SetTrigger(_animIDAttack);
        _cooldown = AttackCooldown;
    }
}
