using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, ICollectible
{
    [SerializeField, Tooltip("Health gained when picked up")] int healthGained = 1;
    public void Collected(PlayerController player)
    {
        if (player.MaxHealth())
            return;
        else
        {
            player.GainHealth(healthGained);
            Destroy(gameObject);
        }
    }
}