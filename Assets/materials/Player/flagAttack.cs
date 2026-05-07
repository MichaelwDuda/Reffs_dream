using UnityEngine;

public class flagAttack : BaseAttack
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 15f;

    protected override void PerformAttack()
    {
        // Get the main camera
        Transform cam = Camera.main.transform;
        // Spawn at camera position, facing camera direction
        GameObject proj = Instantiate(projectilePrefab, cam.position, cam.rotation);
        // Apply velocity
        Rigidbody rb = proj.GetComponent<Rigidbody>();
        rb.linearVelocity = cam.forward * projectileSpeed;
    }
}
