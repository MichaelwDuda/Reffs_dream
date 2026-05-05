using UnityEngine;

public class enemyMove : MonoBehaviour
{
    public Transform player;

    [Header("Movement Settings")]
    public float moveSpeed = 3f;
    public float rotationSpeed = 10f;
    public float stopDistance = 1.5f;
    bool isWalking = false;
    bool isAttacking = false;
    private Animator anim;
    public float attackRange = 1.5f;
    public float attackCooldown = 1f;
    public int attackDamage = 10;
    private float nextAttackTime = 0f;

    private Rigidbody rb;
    private PlayerHealth playerHealth;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void FixedUpdate()
    {
        if (player == null) return;

        FollowPlayer();
        HandleAttack();
        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isAttacking", isAttacking);
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
            isWalking = true;
            Vector3 move = direction * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + move);
        }
        else
        {
            isWalking = false;
        }
    }
    private void HandleAttack()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            isAttacking = true;

            if (Time.time >= nextAttackTime)
            {
                nextAttackTime = Time.time + attackCooldown;

                if (playerHealth != null)
                    playerHealth.TakeDamage(attackDamage);
            }
        }
        else
        {
            isAttacking = false;
        }
    }
}
