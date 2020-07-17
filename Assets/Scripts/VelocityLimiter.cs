using UnityEngine;

public class VelocityLimiter : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public Vector2 maxVelocity;
    public Vector2 setToVelocity;
    public float maxAngularVelocity;
    public float setToAngularVelocity;
    public bool limitXVelocity = false;
    public bool limitYVelocity = false;
    public bool limitAngularVelocity = false;

    void FixedUpdate()
    {
        Vector2 velocity = rigidbody.velocity;
        if (rigidbody.velocity.x > maxVelocity.x && limitXVelocity)
            velocity.x = setToVelocity.x;
        if (rigidbody.velocity.y > maxVelocity.y && limitYVelocity)
            velocity.y = setToVelocity.y;
        rigidbody.velocity = velocity;
        if (rigidbody.angularVelocity > maxAngularVelocity && limitAngularVelocity)
            rigidbody.angularVelocity = setToAngularVelocity;
    }
}
