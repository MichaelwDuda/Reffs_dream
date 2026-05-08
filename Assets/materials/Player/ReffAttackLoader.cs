using UnityEngine;

public class ReffAttackLoader : MonoBehaviour
{
    public AttackChoice attackChoice;

    void Start()
    {
        string attackName = attackChoice.chosenAttackName;

        BaseAttack attack = GetComponent(attackName) as BaseAttack;
        Attacks attackManager = GetComponent<Attacks>();

        if (attack != null)
        {
            attack.enabled = true;
            attackManager.attackSlot1 = attack;
            Debug.Log("Loaded attack: " + attackName);
        }
        else
        {
            Debug.LogError("Attack not found on Reff: " + attackName);
        }
    }
}
