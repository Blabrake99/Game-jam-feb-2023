using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : MonoBehaviour, Weapon
{
    [Tooltip("Bullet particle effects")] public ParticleSystem flame;

    bool Weapon.On { get { return on; } set { on = value; } }

    public bool on; 
    public void Attack()
    {
        flame.Play();
    }
    public void AttackOff()
    {
        flame.Stop();
    }
}
