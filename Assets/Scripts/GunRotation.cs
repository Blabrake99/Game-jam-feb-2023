using UnityEngine;
using UnityEngine.InputSystem;

public class GunRotation : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToViewportPoint(Mouse.current.position.ReadValue());
        Vector3 dir = mousePos - transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
