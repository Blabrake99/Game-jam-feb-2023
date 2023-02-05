using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpikes : MonoBehaviour
{
    [HideInInspector] public Transform currentPoint;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerController>().Damage(1);
            repositionAtPoint(col.gameObject);
        }
    }
    void repositionAtPoint(GameObject player) 
    {
        if (currentPoint != null)
            player.transform.position = currentPoint.transform.position;
        else
            player.GetComponent<PlayerController>().Respawn();
    }
}
