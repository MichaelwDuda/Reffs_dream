using UnityEngine;

public class AOEAttack : BaseAttack
{
    [Header("AOE Settings")]
    public float radius = 5f;
    public float stunDuration = 2f;
    public float damage = 20;
    public LayerMask enemyLayer;
    public Transform attackOrigin; // usually the player

    protected override void PerformAttack()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("enemy"))
            {
                EnemyHealth hp = hit.GetComponent<EnemyHealth>();
                if (hp != null)
                {
                    hp.TakeDamage(damage);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackOrigin != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(attackOrigin.position, radius);
        }
    }
}


