using UnityEngine;

public class pickUp : MonoBehaviour
{
    [Header("Attack to Give")]
    public BaseAttack attackPrefab;

    [Header("Pickup Settings")]
    public bool autoAssignToFirstEmptySlot = true;
    public int specificSlot = 0; // 0 = auto, 1/2/3 = force slot

    private void OnTriggerEnter(Collider other)
    {
        Attacks attackManager = other.GetComponent<Attacks>();
        if (attackManager == null)
            return;

        // If forcing a specific slot
        if (specificSlot >= 1 && specificSlot <= 3)
        {
            // Only equip if the slot is empty
            if (GetSlot(attackManager, specificSlot) == null)
            {
                Equip(attackManager, specificSlot);
                Destroy(gameObject);
            }

            return; // If slot is full → ignore pickup
        }

        // Auto-assign mode
        if (autoAssignToFirstEmptySlot)
        {
            // Slot 1
            if (attackManager.attackSlot1 == null)
            {
                Equip(attackManager, 1);
                Destroy(gameObject);
                return;
            }

            // Slot 2
            if (attackManager.attackSlot2 == null)
            {
                Equip(attackManager, 2);
                Destroy(gameObject);
                return;
            }

            // Slot 3
            if (attackManager.attackSlot3 == null)
            {
                Equip(attackManager, 3);
                Destroy(gameObject);
                return;
            }

            // All slots full → ignore pickup
            return;
        }
    }

    private BaseAttack GetSlot(Attacks atk, int slot)
    {
        return slot switch
        {
            1 => atk.attackSlot1,
            2 => atk.attackSlot2,
            3 => atk.attackSlot3,
            _ => null
        };
    }

    private void Equip(Attacks atk, int slot)
    {
        BaseAttack newAttack = Instantiate(attackPrefab, atk.transform);
        atk.EquipAttack(slot, newAttack);
    }
}
