using UnityEngine;

public class GrowingGravity : MonoBehaviour
{
    public Rigidbody rb;  // Reference to the Rigidbody component
    public float initialGravityForce = 2f;  // The initial gravity force
    public float gravityGrowthRate = 0.5f;  // How much the gravity grows per second
    public float maxGravityForce = 20f;     // Maximum gravity force to avoid infinite growth
    public float maxFallSpeed = 20f;        // Maximum fall speed limit

    private float currentGravityForce;      // The current gravity force

    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();  // Automatically get Rigidbody if not assigned
        }

        // Start with the initial gravity force
        currentGravityForce = initialGravityForce;
    }

    void FixedUpdate()
    {
        ApplyGrowingGravity();
    }

    void ApplyGrowingGravity()
    {
        // Gradually increase the gravity force over time
        currentGravityForce += gravityGrowthRate * Time.fixedDeltaTime;
        currentGravityForce = Mathf.Clamp(currentGravityForce, initialGravityForce, maxGravityForce); // Clamp to avoid going over the max

        // Apply the growing gravity force downwards
        Vector3 gravity = Vector3.down * currentGravityForce;

        // Smoothly apply gravity
        rb.linearVelocity += gravity * Time.fixedDeltaTime;

        // Limit the maximum fall speed to avoid falling too fast
        if (rb.linearVelocity.y < -maxFallSpeed)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, -maxFallSpeed, rb.linearVelocity.z);
        }
    }
}
