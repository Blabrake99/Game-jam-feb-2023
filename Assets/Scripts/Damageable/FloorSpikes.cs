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
        {
            if (player.GetComponent<PlayerController>().Health > 0)
            {
                player.transform.position = new Vector3(currentPoint.transform.position.x,
                    currentPoint.transform.position.y, player.transform.position.z);
            }
        }
        else
            player.GetComponent<PlayerController>().Respawn();
    }
}
