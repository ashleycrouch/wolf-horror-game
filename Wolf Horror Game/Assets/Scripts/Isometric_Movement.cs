using UnityEngine;

public class Isometric_Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public bool isSprinting = false;
    public Vector2 inputVector;
    public int walkSpeed;
    public int sprintMultiplier;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 moveVector = inputVector * walkSpeed;
        if (isSprinting) moveVector *= sprintMultiplier;

        rb.linearVelocity = moveVector;
    }
}