using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlsInputs : MonoBehaviour
{
    [Header("Character Input Values")]
    public Vector2 MoveInput;
    public float AttackInput;
    public float InteractInput;
    public float EquipWeapon1Input, EquipWeapon2Input, EquipWeapon3Input;
    
    [Header("Movement Settings")]
    public bool AnalogMovement;
    
    public void OnMove(InputValue value)
    {
        MoveInput = value.Get<Vector2>();
    }

    public void OnAttack(InputValue value)
    {
        AttackInput = value.Get<float>();
    }

    public void OnInteract(InputValue value)
    {
        InteractInput = value.Get<float>();
    }

    public void OnEquipWeapon1(InputValue value)
    {
        EquipWeapon1Input = value.Get<float>();
    }

    public void OnEquipWeapon2(InputValue value)
    {
        EquipWeapon2Input = value.Get<float>();
    }

    public void OnEquipWeapon3(InputValue value)
    {
        EquipWeapon3Input = value.Get<float>();
    }
}
