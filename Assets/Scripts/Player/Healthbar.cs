using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    public PlayerController playerHealth;

    private string ability;
    // Update is called once per frame

    private void Start()
    {
        ability = "none";
    }

    void Update()
    {
       
        if (ability == "bat")
        {
            slider.value = playerHealth.batHealth;
        } else 
        {
            slider.value = playerHealth.health;
        }
    }

    public void setHealthBar(string ability)
    {
        this.ability = ability;
        print("setHealthBar");
        if (ability == "bat")
        {
            slider.maxValue = 2;
            RectTransform backgroundRT = slider.transform.Find("Background").GetComponent<RectTransform>();
            RectTransform fillAreaRT = slider.transform.Find("Fill Area").GetComponent<RectTransform>();
            backgroundRT.offsetMax = new Vector2(-75, backgroundRT.offsetMax.y); // -50 is the new "right" value, keep the original "top" value
            fillAreaRT.offsetMax = new Vector2(-75, fillAreaRT.offsetMax.y);
        }
        else
        {
            slider.maxValue = 7;
            RectTransform backgroundRT = slider.transform.Find("Background").GetComponent<RectTransform>();
            RectTransform fillAreaRT = slider.transform.Find("Fill Area").GetComponent<RectTransform>();
            backgroundRT.offsetMax = new Vector2(0, backgroundRT.offsetMax.y); // -50 is the new "right" value, keep the original "top" value
            fillAreaRT.offsetMax = new Vector2(0, fillAreaRT.offsetMax.y);
        }
    }
}






