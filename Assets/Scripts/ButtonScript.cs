using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
   public void Play()
    {
        SceneManager.LoadScene("SampleScene 2 - the scenening");
    }

    public void NoPlay()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
