using UnityEngine;

public class EquipWeaponAction : MonoBehaviour
{
    public GameObject[] Weapons;
    
    [HideInInspector] public int WeaponNumber;
    
    private PlayerControlsInputs _input;
    
    void Awake()
    {
        _input = GetComponent<PlayerControlsInputs>();
    }

    void Update()
    {
        ChangeWeapon();
    }
    
    private void ChangeWeapon()
    {
        if (_input.EquipWeapon1Input > 0f && _input.EquipWeapon2Input > 0f && _input.EquipWeapon3Input > 0f)
        {
            WeaponNumber = -1;
        }
        else if (_input.EquipWeapon1Input > 0f && _input.EquipWeapon2Input > 0f)
        {
            WeaponNumber = -1;
        }
        else if (_input.EquipWeapon1Input > 0f && _input.EquipWeapon3Input > 0f)
        {
            WeaponNumber = -1;
        }
        else if (_input.EquipWeapon2Input > 0f && _input.EquipWeapon3Input > 0f)
        {
            WeaponNumber = -1;
        }
        else if (_input.EquipWeapon1Input > 0f)
        {
            WeaponNumber = 0;
        }
        else if (_input.EquipWeapon2Input > 0f)
        {
            WeaponNumber = 1;
        }
        else if (_input.EquipWeapon3Input > 0f)
        {
            WeaponNumber = 2;
        }
        
        EquipWeapon();
    }

    private void EquipWeapon()
    {
        if (WeaponNumber >= 0)
        {
            for (int i = 0; i < Weapons.Length; i++)
            {
                if (i == WeaponNumber)
                {
                    Weapons[i].SetActive(true);
                }
                else
                {
                    Weapons[i].SetActive(false);
                }
            }
        }
    }
}
