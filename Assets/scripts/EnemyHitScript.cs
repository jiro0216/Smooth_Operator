using UnityEngine;

public class EnemyHitScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object tagged as "Bullet"
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Enemy collided with Bullet.");
            // Destroy the enemy GameObject
            Destroy(gameObject);
        }
    }
}