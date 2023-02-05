using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        IDamageble hit = col.GetComponent<IDamageble>();
        if(hit != null)
        {
            hit.Damage(100);
        }
    }
}
