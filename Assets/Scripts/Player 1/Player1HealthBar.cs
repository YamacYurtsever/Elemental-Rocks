using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1HealthBar : MonoBehaviour
{
    //public variables
    public Slider player1Slider;

    public void SetMaxHealth(int maxHealth)
    {
        //set max health
        player1Slider.maxValue = maxHealth;
        player1Slider.value = maxHealth;
    }

    public void SetHealth(int health)
    {
        //set health
        player1Slider.value = health;
        this.transform.gameObject.SetActive(true);
    }
}
