using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2HealthBar : MonoBehaviour
{
    //public variables
    public Slider player2Slider;

    public void SetMaxHealth(int maxHealth)
    {
        //set max health
        player2Slider.maxValue = maxHealth;
        player2Slider.value = maxHealth;
    }

    public void SetHealth(int health)
    {
        //set health
        player2Slider.value = health;
        this.transform.gameObject.SetActive(true);
    }
}
