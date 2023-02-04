using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Bullet variables")]
    [SerializeField, Tooltip("Bullet Speed")] float projectileSpeed = 1f;
    [SerializeField, Tooltip("Damage of bullet")] int damage = 1;
    [SerializeField, Tooltip("How long till the bullet despawns")] float projectileDuration = 2f;
    [SerializeField, Tooltip("Does gravity effect the bullet")] bool useGravity = false;
    [SerializeField, Tooltip("If the bullet is a Player bullet")] bool playerBullet = false;
    [SerializeField, Tooltip("Direction of the bullet")] Direction dir = Direction.Right;
    private Rigidbody rb;

    private void Start()
    {
        //sets the rigidbody
        rb = GetComponent<Rigidbody>();
        rb.useGravity = useGravity;
        //bullet gets destroyed when the times up
        Destroy(this.gameObject, projectileDuration);
    }
    private void Update()
    {
        if (dir == Direction.Right)
        {
            rb.AddForce(transform.right * projectileSpeed);
        } 
        else if(dir == Direction.Left)
        {
            rb.AddForce(-transform.right * projectileSpeed);
        } 
        else if (dir == Direction.Forward)
        {
            rb.AddForce(transform.forward * projectileSpeed);
        }
        else
        {
            rb.AddForce(-transform.forward * projectileSpeed);
        }
    }
    protected void OnTriggerEnter(Collider col)
    {
        IDamageble hit = col.GetComponent<IDamageble>();
        if (col.isTrigger)
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), col);
            return;
        }
        if(hit != null)
        {
            //if a player bullet hits an enemy do damage
            if(playerBullet && col.tag == "Enemy")
            {
                hit.Damage(damage);
                Destroy(this.gameObject);
            }
            //if a enemy bullet hits an player do damage
            if (!playerBullet && col.tag == "Player")
            {
                hit.Damage(damage);
                Destroy(this.gameObject);
            }
        }
        if(hit == null)
        {
            //this is if the bullet hits a wall
            Destroy(this.gameObject);
        }    
    }
    enum Direction
    {
        Right,
        Left,
        Forward,
        Back
    }
}
