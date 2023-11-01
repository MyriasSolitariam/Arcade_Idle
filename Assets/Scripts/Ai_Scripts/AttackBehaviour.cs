using UnityEngine;

public class AttackBehaviour : MonoBehaviour, IBehaviour
{
    private Animator _anim;
    private FieldOfView _fow;

    private int _animIDAttack;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _fow = GetComponent<FieldOfView>();

        _animIDAttack = Animator.StringToHash("Attack");
    }

    public void Behave()
    {
        _anim.SetTrigger(_animIDAttack);
    }

    public float Evaluate()
    {
        if (_fow.VisibleTargets.Count > 0)
            return 0.5f;
        else
            return 0f;
    }
}
