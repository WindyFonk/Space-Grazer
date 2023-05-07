using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController;

public class HealthOrbBehavior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PlayerControllerStatic.playerController.currentHealth > 3)
            {
                PlayerControllerStatic.playerController.setScores(20);
            }
            else
            {
                PlayerControllerStatic.playerController.takeDamage(-1);
            }
            Destroy(gameObject);
        }
    }
}
