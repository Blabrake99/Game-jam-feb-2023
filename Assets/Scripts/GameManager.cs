using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void Pause()
    {
        GameObject menu = GameObject.FindGameObjectWithTag("PauseMenu");
        if (menu != null)
        {
            menu.transform.GetChild(0).gameObject.SetActive(!menu.transform.GetChild(0).gameObject.activeSelf);
        }
    }
}
