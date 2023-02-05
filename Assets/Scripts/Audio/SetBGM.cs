using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBGM : MonoBehaviour
{
    public enum Theme
    {
        Going_Somewhere = 1,
        Boss_Battle
    }

    public Theme theme = Theme.Going_Somewhere;
    AudioManager manager;
    private bool played = false;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(manager == null)
            manager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" || played)
        {
            played = true;
            switch (theme)
            {
                case Theme.Going_Somewhere:
                    //Debug.Log("Playing going somewhere");
                    manager.playGoingSomewhere();
                    break;
                case Theme.Boss_Battle:
                    //Debug.Log("Playing boss");

                    manager.playBossTheme();
                    break;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        played = false;
    }
}
