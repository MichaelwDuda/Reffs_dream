using UnityEngine;

public class AOEAttack : BaseAttack
{
    [Header("AOE Settings")]
    public float radius = 5f;
    public float stunDuration = 2f;
    public LayerMask enemyLayer;
    public Transform attackOrigin; // usually the player

    protected override void PerformAttack()
    {
        // Visualize or spawn VFX here if you want

        Collider[] hits = Physics.OverlapSphere(attackOrigin.position, radius, enemyLayer);

        foreach (Collider hit in hits)
        {
            EnemyStun stun = hit.GetComponent<EnemyStun>();
            if (stun != null)
            {
                stun.ApplyStun(stunDuration);
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


