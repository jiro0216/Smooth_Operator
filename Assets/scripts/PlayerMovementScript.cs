using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 100f;
    public float brakeForce = 20f;

    public GameManager gameManager;

    private Rigidbody rb;

    private void Start()
    {
        // Get the Rigidbody component attached to the GameObject
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Get user input for movement and turning
        float moveInput = Input.GetAxis("Vertical");  // W/S or Up/Down arrow keys
        float turnInput = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow keys

        // Calculate rotation
        float turnAmount = turnInput * turnSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turnAmount, 0f);

        // Apply rotation
        rb.MoveRotation(rb.rotation * turnRotation);

        // Apply forward force for movement if there is no turn input
        if (Mathf.Approximately(turnInput, 0f))
        {
            Vector3 moveDirection = transform.forward * moveInput * moveSpeed;
            rb.AddForce(moveDirection);
        }

        // Apply brakes when no movement input is given
        if (Mathf.Approximately(moveInput, 0f))
        {
            ApplyBrakes();
        }

        // Lock Y-axis position
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
    }

    private void ApplyBrakes()
    {
        Vector3 currentVelocity = rb.velocity;
        Vector3 brakeForceVector = -currentVelocity.normalized * brakeForce;
        brakeForceVector.y = 0f; // Make sure Y component is zero
        rb.AddForce(brakeForceVector);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Game over condition: When the turret collides with an enemy.
            gameManager.GameOver();
        }

    }
}
