using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float speed;

    void Update()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        if (player != null) // Check if the player reference is valid
        {
            // Calculate the direction from the enemy to the player
            Vector3 directionToPlayer = (player.position - transform.position).normalized;

            // Move the enemy in the direction of the player
            transform.Translate(directionToPlayer * speed * Time.deltaTime);
        }
    }
}
