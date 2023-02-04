using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalJump : MonoBehaviour, ICollectible
{
    [SerializeField, Tooltip("Jumps gained when picked up")] int jumpsGained = 1;
    public void Collected(PlayerController player)
    {
        player.AddJumps(jumpsGained);
        Destroy(gameObject);
    }
}