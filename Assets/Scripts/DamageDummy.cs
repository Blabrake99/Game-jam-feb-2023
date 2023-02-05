using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDummy : MonoBehaviour, IDamageble
{
    public int Health { get { return health; } set { health = value; } }
    int health = 1000000;
    public void Damage(int amount)
    {
        print("hit");
        Health -= amount;
    }
}
