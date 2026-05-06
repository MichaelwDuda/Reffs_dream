using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 30;

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
