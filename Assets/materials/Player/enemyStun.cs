using UnityEngine;

public class EnemyStun : MonoBehaviour
{
    private bool isStunned = false;
    private float stunTimer = 0f;
    private Rigidbody rb;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isStunned)
        {
            stunTimer -= Time.deltaTime;
            if (stunTimer <= 0)
            {
                EndStun();
            }
        }
    }

    public void ApplyStun(float duration)
    {
        isStunned = true;
        stunTimer = duration;

        // Stop movement
        if (rb != null)
            rb.linearVelocity = Vector3.zero;

    }

    private void EndStun()
    {
        isStunned = false;

    }
}