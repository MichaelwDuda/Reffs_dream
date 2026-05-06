using UnityEngine;

public class Stick : BaseAttack
{
    public float damage = 10f;
    public float range = 2f;
    public float radius = 1f;
    public LayerMask hitLayers;

    [Header("Optional Animation")]
    public Animator animator;
    public string attackTrigger = "Attack";

    protected override void PerformAttack()
    {
        // Play animation if assigned
        if (animator != null && !string.IsNullOrEmpty(attackTrigger))
            animator.SetTrigger(attackTrigger);

        // Hit detection
        Vector3 origin = transform.position + transform.forward * range * 0.5f;
        Collider[] hits = Physics.OverlapSphere(origin, radius, hitLayers);

        foreach (Collider hit in hits)
        {
            EnemyHealth hp = hit.GetComponent<EnemyHealth>();
            if (hp != null)
            {
                hp.TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 origin = transform.position + transform.forward * range * 0.5f;
        Gizmos.DrawWireSphere(origin, radius);
    }
}
