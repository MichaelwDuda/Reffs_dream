using UnityEngine;

public class CardThrow : ProjectileAttack
{
    [SerializeField] private float xSpeed = 720f;
    [SerializeField] private float ySpeed = 90f;
    [SerializeField] private float zSpeed = 45f;

    void Update()
    {
        transform.Rotate(
            new Vector3(xSpeed, ySpeed, zSpeed) * Time.deltaTime,
            Space.Self
        );
    }
}
