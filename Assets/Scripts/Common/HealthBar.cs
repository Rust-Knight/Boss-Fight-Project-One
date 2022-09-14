using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Gradient graident;
    public Image fill;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = graident.Evaluate(1f);
    }
    
   public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = graident.Evaluate(slider.normalizedValue);
    }
}
