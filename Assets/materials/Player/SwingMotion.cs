using UnityEngine;

public class SwingMotion : MonoBehaviour
{
    public float swingSpeed = 360f; // degrees per second
    public float swingDuration = 0.25f;
    public float damage = 10f;

    private float timer = 0f;

    void Update()
    {
        // Rotate around local Y axis
        transform.Rotate(Vector3.up * swingSpeed * Time.deltaTime);

        timer += Time.deltaTime;
        if (timer >= swingDuration)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyHealth hp = other.GetComponent<EnemyHealth>();
        if (hp != null)
        {
            hp.TakeDamage(damage);
        }
    }
}
