using UnityEngine;

public class CardThrow : MonoBehaviour
{
    [SerializeField] private float xSpeed = 720f;
    [SerializeField] private float ySpeed = 90f;
    [SerializeField] private float zSpeed = 45f;
    public int damage = 10;
    public float lifeTime = 3f;

    void Update()
    {
        transform.Rotate(
            new Vector3(xSpeed, ySpeed, zSpeed) * Time.deltaTime,
            Space.Self
            
        );
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            // Damage
            EnemyHealth health = collision.gameObject.GetComponent<EnemyHealth>();
            if (health != null)
                health.TakeDamage(damage);

        }

        Destroy(gameObject);
    }
}
