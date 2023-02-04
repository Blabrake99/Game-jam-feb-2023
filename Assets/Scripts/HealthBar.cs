using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //[SerializeField] Slider slider;
    //[SerializeField] Gradient gradient;
    //[SerializeField] Image fill;
    [SerializeField] Image image;
    [SerializeField] Sprite[] sprites;
    private int health;
    private void Start()
    {
        SetMaxHealth(FindObjectOfType<PlayerController>().Health);
    }
    public void SetMaxHealth(int _health)
    {

        health = _health;
        image.sprite = sprites[health - 1];
            //slider.maxValue = health;
            //slider.value = health;

            //fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int _health)
    {
        health = _health;
        if(health > 0)
            image.sprite = sprites[health - 1];
        //slider.value = health;

        //fill.color = gradient.Evaluate(slider.normalizedValue);
    }



}
