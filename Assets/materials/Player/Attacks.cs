using UnityEngine;

public class Attacks : MonoBehaviour
{
     [Header("Equipped Attacks")]
    public BaseAttack attackSlot1;   // J key
    public BaseAttack attackSlot2;   // K key
    public BaseAttack attackSlot3;   // L key

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && attackSlot1 != null)
            attackSlot1.DoAttack();

        if (Input.GetKeyDown(KeyCode.K) && attackSlot2 != null)
            attackSlot2.DoAttack();

        if (Input.GetKeyDown(KeyCode.L) && attackSlot3 != null)
            attackSlot3.DoAttack();
    }
}
