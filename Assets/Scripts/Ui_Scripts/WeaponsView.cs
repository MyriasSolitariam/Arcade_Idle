using UnityEngine;

public class WeaponsView : MonoBehaviour
{
    [SerializeField] private EquipWeaponAction _equipWeaponAction;

    private Animator _anim;

    private int _animIDAxe;
    private int _animIDPickaxe;
    private int _animIDSword;

    void Awake()
    {
        _anim = GetComponent<Animator>();
        
        _animIDAxe = Animator.StringToHash("Axe");
        _animIDPickaxe = Animator.StringToHash("Pickaxe");
        _animIDSword = Animator.StringToHash("Sword");
    }

    void Update()
    {
        ChangeWeapon();
    }

    private void ChangeWeapon()
    {
        if (_equipWeaponAction.WeaponNumber == 0)
        {
            _anim.SetTrigger(_animIDAxe);
        }
        else if (_equipWeaponAction.WeaponNumber == 1)
        {
            _anim.SetTrigger(_animIDPickaxe);
        }
        else if (_equipWeaponAction.WeaponNumber == 2)
        {
            _anim.SetTrigger(_animIDSword);
        }
    }
}
