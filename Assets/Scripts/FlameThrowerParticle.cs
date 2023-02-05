using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerParticle : MonoBehaviour
{
    [SerializeField, Tooltip("If the bullet is a Player bullet")] bool playerBullet = true;
    [SerializeField, Tooltip("Damage of bullet")] int damage = 1;
    private void OnParticleCollision(GameObject col)
    {
        IDamageble hit = col.GetComponent<IDamageble>();
        if (col.GetComponent<Collider>().isTrigger)
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), col.GetComponent<Collider>());
            return;
        }
        if (hit != null)
        {
            //if a player bullet hits an enemy do damage
            if (playerBullet && col.tag == "Enemy")
            {
                hit.Damage(damage);
            }
            //if a enemy bullet hits an player do damage
            if (!playerBullet && col.tag == "Player")
            {
                hit.Damage(damage);
            }
        }
    }
}
