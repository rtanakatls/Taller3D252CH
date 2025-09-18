using UnityEngine;

public class PlayerMovement : Movement
{
    protected override void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rb.linearVelocity = new Vector3(h * movementSpeed, rb.linearVelocity.y, v * movementSpeed);
    }
}
