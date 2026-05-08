using UnityEngine;

public class pickUp : MonoBehaviour
{
    [Header("Attack To Give Player")]
    public string attackName;

    private void OnTriggerEnter(Collider other)
    {
        Attacks attackManager = other.GetComponent<Attacks>();
        if (attackManager == null) return;

        // Find the attack script on the player by name
        BaseAttack attack = other.GetComponent(attackName) as BaseAttack;
        if (attack == null)
        {
            Debug.LogError("Player does not have attack script: " + attackName);
            return;
        }

        // Add to first empty slot
        if (attackManager.attackSlot1 == null)
            attackManager.attackSlot1 = attack;
        else if (attackManager.attackSlot2 == null)
            attackManager.attackSlot2 = attack;
        else if (attackManager.attackSlot3 == null)
            attackManager.attackSlot3 = attack;
        else
        {
            Debug.Log("All attack slots full");
            return;
        }

        // Enable the attack script
        attack.enabled = true;

        Debug.Log("Activated attack: " + attackName);

        Destroy(gameObject);
    }
}
