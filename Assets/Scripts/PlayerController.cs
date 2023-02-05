using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
public class PlayerController : MonoBehaviour, IDamageble
{
    [Header("Movement Variables")]
    [SerializeField, Tooltip("The speed at which you walk")] private float walkSpeed = 5f;
    [SerializeField, Tooltip("The speed at which you run")] private float runSpeed = 7f;
    [SerializeField, Tooltip("How high you jump")] private float jumpSpeed = 5f;
    [SerializeField, Tooltip("Amount of Jumps")] private int amountOfJumps = 1;
    [SerializeField, Tooltip("Speed at whick you decend while wall sliding")] private float wallSlidingSpeed = .5f;
    [SerializeField, Tooltip("The power Of the wall jump")] Vector2 wallJumpPower = new Vector2(8f, 16f);
    [SerializeField, Tooltip("The amount of time you are stuck wall jumping")] float wallJumpingDuration = .2f;

    [Header("Weapon Variables")]
    [SerializeField, Tooltip("The fire rate of your gun")] private float fireRate = .2f;
    [SerializeField, Tooltip("The projectile you are shooting")] private GameObject projectile;
    [SerializeField, Tooltip("Loadout for the player")] GameObject[] weapons = new GameObject[4];
    [SerializeField, Tooltip("Current selected weapon")] GameObject currentWeapon;

    [Header("Health Variables")]
    [SerializeField, Tooltip("Players health")] private int health = 10;
    [SerializeField, Tooltip("IFrames")] private float damageCooldown;

    [Header("Don't touch PATRICK")]
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private Transform wallCheck;
    [SerializeField, Tooltip("The tip of the gun")] Transform gunTip;
    [SerializeField, Tooltip("Grounded Point")] Transform groundedPoint;
    [SerializeField] LayerMask mask;
    public int Health { get { return health; } set { health = value; } }
    private int maxHealth;
    private GameManager gameManager;
    private Vector3 respawnPoint;
    private PlayerActions actions;
    private float yInput;
    private int jumpsDone;
    private bool grounded => IsGrounded();
    private Rigidbody rb;
    private float damagedTimer, justjumpedTimer, distToGround, shootTimer;
    private Vector2 inputVector;
    private bool isWallJumping;
    private bool isWallSliding;
    private float wallJumpDirection;
    private float wallJumpingTime = .1f;
    private float wallJumpingCounter;
    private HealthBar bar;
    private AudioManager audioManager;
    private Quaternion StartEularAngles;
    private Animator anim;
    private float shootAnimTimer;
    private float isShooting;
    void Start()
    { 
        rb = GetComponent<Rigidbody>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
        respawnPoint = this.transform.position;
        maxHealth = health;
        gameManager = FindObjectOfType<GameManager>();
        bar = FindObjectOfType<HealthBar>();
        //this is for setting up the player controls
        actions = new PlayerActions();
        actions.Actions.Enable();
        actions.Actions.OnJump.performed += OnJump;
        //actions.Actions.OnFire.performed += OnFire;
        actions.Actions.OnPause.performed += OnPause;
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        StartEularAngles = transform.rotation;
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        isShooting = actions.Actions.OnFire.ReadValue<float>();
        //movement
        if (!isWallJumping)
        {
            inputVector = actions.Actions.OnMove.ReadValue<Vector2>();
            //yInput = inputVector.y;
            rb.velocity = new Vector3(inputVector.x * walkSpeed, rb.velocity.y, 0);
        }
        if (rb.velocity.x > 0)
        {
            transform.rotation = StartEularAngles;
            PlayAnimation("IsMoving");
        } else if (rb.velocity.x < 0)
        {
            transform.rotation = Quaternion.Inverse(StartEularAngles);
            PlayAnimation("IsMoving");
        } else
        {
            StopAnimation("IsMoving");
        }
        if (grounded)
        {
            StopAnimation("IsJumping");
            StopAnimation("IsWallSliding");
            PlayAnimation("IsGrounded");
            //resets jump counters when on ground
            if (jumpsDone != amountOfJumps)
                jumpsDone = amountOfJumps;
        }
        else
        {
            StopAnimation("IsGrounded");
            PlayAnimation("IsJumping");
            WallSlide();
            WallJump();
        }  
        if(!isWallSliding)
        {
            if (isShooting > .2f) //Shooting ON 
            {
                PlayAnimation("IsShooting");
                if (shootTimer <= 0)
                {
                    if (!currentWeapon.GetComponent<Weapon>().On)
                        currentWeapon.GetComponent<Weapon>().Attack();
                    //SpawnBullet
                    shootTimer = fireRate;
                    shootAnimTimer = 1f;
                    audioManager.playFlamethrower();
                }
            }
            else //Shooting Off
            {
                currentWeapon.GetComponent<Weapon>().AttackOff();
                shootAnimTimer -= Time.deltaTime;
                StopAnimation("IsShooting");
                audioManager.stopFlamethrower();
            }
        }
        if (justjumpedTimer > 0)
            justjumpedTimer -= Time.deltaTime;
        if (damagedTimer > 0)
            damagedTimer -= Time.deltaTime;
        if (shootTimer > 0)
            shootTimer -= Time.deltaTime;            
    }
    #region Health
    public bool MaxHealth()
    {
        if (health == maxHealth)
            return true;
        else
        {
            return false;
        }
    }
    public void GainHealth(int amount)
    {
        if (health + amount > maxHealth)
            health = maxHealth;
        else
        {
            health += maxHealth;
        }
    }
    public void Damage(int amount)
    {
        if (Time.time > damagedTimer)
        {
            damagedTimer = Time.time + damageCooldown;
            Health -= amount;
            //this is where i'd put the health bar code
            if (bar != null)
                bar.SetHealth(Health);
        }
        if (Health < 1)
        {
            Respawn();
        }
    }
    public void Respawn()
    {
        transform.position = respawnPoint;
        health = maxHealth;
        if (bar != null)
            bar.SetHealth(Health);
    }
    public void setSpawnLocation(Vector3 newSpawnLocation)
    {
        respawnPoint = newSpawnLocation;
    }
    #endregion

    #region ButtonPresses
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (isWallSliding)
            {
                if (wallJumpingCounter > 0f)
                {
                    StopAnimation("IsWallSliding");
                    PlayAnimation("WallJump");
                    isWallJumping = true;
                    rb.velocity = new Vector2(wallJumpDirection * wallJumpPower.x, wallJumpPower.y);
                    wallJumpingCounter = 0;
                    audioManager.playJump();

                    Invoke(nameof(StopWallJumping), wallJumpingDuration);
                }
            }
            else
            {
                if (jumpsDone > 0)
                {
                    PlayAnimation("IsJumping");
                    StopAnimation("WallJump");
                    StopAnimation("IsWallSliding");
                    //makes the player jump
                    rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                    rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
                    justjumpedTimer = .1f;
                    jumpsDone--;
                    audioManager.playJump();
                }
            }
        }
    }
    //public void OnFire(InputAction.CallbackContext context)
    //{
    //    if (context.action.WasPressedThisFrame())
    //    {

    //    }
    //}
    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            gameManager.Pause();
        }
    }
    public void OnSwitch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //uncomment this later

            //Vector2 temp = actions.Actions.OnSwitch.ReadValue<Vector2>();
            //if (temp.x > 0)
            //{
            //    switchWeapon(0);
            //    return;
            //}
            //if (temp.x < 0)
            //{
            //    switchWeapon(1);
            //    return;
            //}
            //if (temp.y > 0)
            //{
            //    switchWeapon(2);
            //    return;
            //}
            //if (temp.y < 0)
            //{
            //    switchWeapon(3);
            //    return;
            //}
        }
    }
    void switchWeapon(int num)
    {
        if (currentWeapon != weapons[num] && weapons[num] != null)
        {
            GameObject temp = Instantiate(weapons[num], currentWeapon.transform.position, currentWeapon.transform.rotation, gameObject.transform);
            Destroy(currentWeapon);
            currentWeapon = temp;
        }
    }
    #endregion

    #region For walls
    private bool IsOnWall()
    {
        Collider[] temp = Physics.OverlapSphere(wallCheck.position, .2f, wallLayer);
        if (temp.Length > 0)
            return true;
        else
            return false;
    }
    private void WallSlide()
    {
        if (IsOnWall() && !IsGrounded() && inputVector.x != 0 && !isWallJumping)
        {
            if (inputVector.x > 0)
            {
                transform.rotation = Quaternion.Inverse(StartEularAngles);
            }
            if (inputVector.x < 0)
            {
                transform.rotation = StartEularAngles;
            }
                PlayAnimation("IsWallSliding");
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            StopAnimation("IsWallSliding");
            isWallSliding = false;
        }
    }
    private void WallJump()
    { 
        if(isWallSliding)
        {
            isWallJumping = false;
            if (inputVector.x > 0f)
            {
                wallJumpDirection = -1;
            }
            if(inputVector.x < 0f)
            {
                wallJumpDirection = 1;
            }
            wallJumpingCounter = wallJumpingTime;
            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }
    }
    private void StopWallJumping()
    {
        isWallJumping = false;
    }

    //this checks for if the players grounded 
    private bool IsGrounded()
    {
        if (justjumpedTimer > 0)
            return false;
        isWallSliding = false;
        return Physics.Raycast(groundedPoint.transform.position, -Vector3.up, distToGround - .2f,mask,QueryTriggerInteraction.Ignore);
    }
    #endregion

    public void AddJumps(int jumps)
    {
        amountOfJumps += jumps;
    }
    private void OnTriggerEnter(Collider col)
    {
        ICollectible collectible = col.GetComponent<ICollectible>();
        if (collectible != null)
        {
            collectible.Collected(this);
        }
    }
    /// <summary>
    /// Call this for anytime you need to play an animation 
    /// </summary>
    /// <param name="animName"></param>
    public void PlayAnimation(string BoolName)
    {
        anim.SetBool(BoolName, true);
    }

    /// <summary>
    /// Call this for anytime you need to stop an animation
    /// </summary>
    /// <param name="BoolName"></param>
    public void StopAnimation(string BoolName)
    {
        anim.SetBool(BoolName, false);
    }
}