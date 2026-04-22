using UnityEngine;

public class enemyMove : MonoBehaviour
{
    public Transform player;

    [Header("Movement Settings")]
    public float moveSpeed = 3f;
    public float rotationSpeed = 10f;
    public float stopDistance = 1.5f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (player == null) return;

        FollowPlayer();
    }

    private void FollowPlayer()
    {
        // Direction toward player
        Vector3 direction = (player.position - transform.position).normalized;

        // Rotate toward player
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime));

        // Distance check
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > stopDistance)
        {
            // Move toward player
            Vector3 move = direction * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + move);
        }
    }
}
