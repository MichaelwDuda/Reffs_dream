using UnityEngine;

public class Chair : ProjectileAttack
{
    public int damage = 10;
    public float knockbackForce = 10f;
    public float lifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            // Damage
            EnemyHealth health = collision.gameObject.GetComponent<EnemyHealth>();
            if (health != null)
                health.TakeDamage(damage);

            // Knockback
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            if (enemyRb != null)
            {
                Vector3 direction = (collision.transform.position - transform.position).normalized;
                enemyRb.AddForce(direction * knockbackForce, ForceMode.Impulse);
            }
        }

        Destroy(gameObject);
    }
}
