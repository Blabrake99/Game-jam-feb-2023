using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour, IDamageble
{
    [Header("Movement Variables")]
    [SerializeField, Tooltip("Why are you even reading the tool tip")] float walkSpeed;
    [SerializeField, Tooltip("Why are you even reading the tool tip")] float runSpeed;
    [SerializeField, Tooltip("Movement in the air while falling")] float airSpeed;
    [SerializeField, Tooltip("How high you jump")] float jumpSpeed;

    [Header("Projectile Variables")]
    [SerializeField, Tooltip("The fire rate of your gun")] float fireRate;
    [SerializeField, Tooltip("The projectile you are shooting")] GameObject projectile;

    [Header("Health Variables")]
    [SerializeField, Tooltip("Players health")] int health;
    [SerializeField, Tooltip("IFrames")] float damageCooldown;

   // [Header("Don't touch PATRICK")]
    public int Health { get { return health; } set { health = value; } }

    private Rigidbody rb;
    protected float damagedTimer, justjumpedTimer, distToGround;


    void Start()
    {
       rb = GetComponent<Rigidbody>(); 
    }
    void FixedUpdate()
    {
        //make Movement
    }

    public void Damage(int amount)
    {
        if (Time.time > damagedTimer)
        {
            damagedTimer = Time.time + damageCooldown;
            Health -= amount;
            //bar.SetHealth(Health);
        }
        if (Health < 1)
        {
            Respawn();
        }
    }
    void Respawn()
    {
        //later
    }
}
