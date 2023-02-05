using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : MonoBehaviour, Weapon
{
    [SerializeField, Tooltip("Gun Tip of Gun")] Transform gunTip;
    [SerializeField, Tooltip("Bullet particle effects")] ParticleSystem flame;
    [SerializeField, Tooltip("Flame duration")] float flameDuration = .2f;
    private float duration;
    private bool flameOn;
    public void Attack()
    {
        duration += flameDuration;
        if (!flameOn)
        {
            flameOn = true;
            StartCoroutine(FireFlame());
        }
    }
    IEnumerator FireFlame()
    {
        flame.Play();
        yield return new WaitForSeconds(duration);
        flame.Stop();
        flameOn = false;
    }
}
