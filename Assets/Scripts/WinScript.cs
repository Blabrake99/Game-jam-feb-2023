using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        SceneManager.LoadScene(2);
    }
}
