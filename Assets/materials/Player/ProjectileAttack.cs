using UnityEngine;

public class ProjectileAttack : BaseAttack
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 15f;

    protected override void PerformAttack()
    {
        GameObject proj = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        Rigidbody rb = proj.GetComponent<Rigidbody>();
        rb.linearVelocity = firePoint.forward * projectileSpeed;
    }
}
