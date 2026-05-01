using UnityEngine;
using UnityEngine.InputSystem;

public class Attacks : MonoBehaviour
{
     [Header("Equipped Attacks")]
    public BaseAttack attackSlot1;   
    public BaseAttack attackSlot2; 
    public BaseAttack attackSlot3;
    private CharacterController controller;


    private void OnAttack1(InputAction.CallbackContext ctx)
    {
        attackSlot1?.DoAttack();
    }

    private void OnAttack2(InputAction.CallbackContext ctx)
    {
        attackSlot2?.DoAttack();
    }

    private void OnAttack3(InputAction.CallbackContext ctx)
    {
        attackSlot3?.DoAttack();
    }
    public void EquipAttack(int slot, BaseAttack newAttack)
    {
        switch (slot)
        {
            case 1: attackSlot1 = newAttack; break;
            case 2: attackSlot2 = newAttack; break;
            case 3: attackSlot3 = newAttack; break;
        }
    }
}
