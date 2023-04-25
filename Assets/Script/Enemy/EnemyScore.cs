using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static PlayerController;

public class EnemyScore : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControllerStatic.playerController.setScores(1);
    }

    private void OnDestroy()
    {
        PlayerControllerStatic.playerController.setScores(5);
    }
}
