using UnityEngine;

public abstract class BaseAttack : MonoBehaviour
{
    public float cooldown = 0.5f;
    protected float nextAttackTime = 0f;

    public virtual void DoAttack()
    {
        if (Time.time < nextAttackTime)
            return;

        nextAttackTime = Time.time + cooldown;
        PerformAttack();
    }

    protected abstract void PerformAttack();
}