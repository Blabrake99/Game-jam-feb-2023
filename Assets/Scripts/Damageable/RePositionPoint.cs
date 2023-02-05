using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RePositionPoint : MonoBehaviour
{
    [SerializeField] FloorSpikes spike;
    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            spike.currentPoint = transform;
        }
    }
}
