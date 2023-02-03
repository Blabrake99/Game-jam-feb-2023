using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
public class PlayerController : MonoBehaviour, IDamageble
{
    [Header("Movement Variables")]
    [SerializeField, Tooltip("Why are you even reading the tool tip")] float walkSpeed;
    [SerializeField, Tooltip("Why are you even reading the tool tip")] float runSpeed;
    [SerializeField, Tooltip("Movement in the air while falling")] float airSpeed;
    [SerializeField, Tooltip("How high you jump")] float jumpSpeed;
    [SerializeField, Tooltip("Amount of Jumps")] int amountOfJumps = 1;
    [Header("Projectile Variables")]
    [SerializeField, Tooltip("The fire rate of your gun")] float fireRate;
    [SerializeField, Tooltip("The projectile you are shooting")] GameObject projectile;

    [Header("Health Variables")]
    [SerializeField, Tooltip("Players health")] int health;
    [SerializeField, Tooltip("IFrames")] float damageCooldown;

    // [Header("Don't touch PATRICK")]
    public int Health { get { return health; } set { health = value; } }
    PlayerActions actions;
    private float yInput;
    private int jumpsDone;
    private bool grounded => IsGrounded();
    private Rigidbody rb;
    protected float damagedTimer, justjumpedTimer, distToGround;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        distToGround = GetComponent<Collider>().bounds.extents.y;

        actions = new PlayerActions();
        actions.Actions.Enable();
        actions.Actions.OnJump.performed += OnJump;
        actions.Actions.OnFire.performed += OnFire;
    }
    private void FixedUpdate()
    {
        //movement
        Vector2 inputVector = actions.Actions.OnMove.ReadValue<Vector2>();
        yInput = inputVector.y;
        rb.velocity = new Vector3(inputVector.x * walkSpeed, rb.velocity.y, 0);
        if (rb.velocity.x > 0)
            transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
        if (rb.velocity.x < 0)
            transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, transform.rotation.w);
        if (grounded)
        {
            //resets jump counters when on ground
            if (jumpsDone != amountOfJumps)
                jumpsDone = amountOfJumps;
        }
        if (justjumpedTimer > 0)
            justjumpedTimer -= Time.deltaTime;
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && jumpsDone > 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            justjumpedTimer = .1f;
            jumpsDone--;
        }
    }
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            print("pew pew");
            //SpawnBullet
        }
    }
    public void Damage(int amount)
    {
        if (Time.time > damagedTimer)
        {
            damagedTimer = Time.time + damageCooldown;
            Health -= amount;
            //this is where i'd put the health bar code

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
    private bool IsGrounded()
    {
        if (justjumpedTimer > 0)
            return false;

        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}
