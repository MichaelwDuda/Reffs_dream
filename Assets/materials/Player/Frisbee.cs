using UnityEngine;
using System.Collections.Generic;

public class Frisbee : MonoBehaviour
{
    public int damage = 10;
    public float bounceRange = 10f;
    public int maxBounces = 3;
    public float speed = 20f;

    private Rigidbody rb;
    private Transform currentTarget;
    private int bounceCount = 0;
    private HashSet<Transform> hitEnemies = new HashSet<Transform>();

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (currentTarget != null)
        {
            Vector3 dir = (currentTarget.position - transform.position).normalized;
            rb.linearVelocity = dir * speed;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("enemy"))
            return;

        Transform enemy = collision.transform;

        // Damage
        EnemyHealth hp = enemy.GetComponent<EnemyHealth>();
        if (hp != null)
            hp.TakeDamage(damage);

        hitEnemies.Add(enemy);

        // Try to find next target
        if (bounceCount < maxBounces && FindNextTarget())
        {
            bounceCount++;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    bool FindNextTarget()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, bounceRange);

        float closestDist = Mathf.Infinity;
        Transform bestTarget = null;

        foreach (Collider c in hits)
        {
            if (!c.CompareTag("enemy"))
                continue;

            if (hitEnemies.Contains(c.transform))
                continue;

            float dist = Vector3.Distance(transform.position, c.transform.position);
            if (dist < closestDist)
            {
                closestDist = dist;
                bestTarget = c.transform;
            }
        }

        if (bestTarget != null)
        {
            currentTarget = bestTarget;
            return true;
        }

        return false;
    }
}
