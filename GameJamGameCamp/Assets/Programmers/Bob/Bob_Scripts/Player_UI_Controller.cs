using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_UI_Controller : MonoBehaviour
{
    //bullet slider that reloads over time and a weapon overlay
    public Slider healthBarSlider;  
    public Text gameOverText;   

    private bool isGameOver = false; 

    void Start()
    {
        //gameOverText.enabled = false; 
    }

    
    void Update()
    {

        healthBarSlider.value = GetComponent<Health_Component>().CurrentHealth / GetComponent<Health_Component>().StartHealth;

    }

    
    //void OnTriggerStay(Collider other)
    //{
        
    //    if (other.gameObject.name == "Fire" && healthBarSlider.value > 0)
    //    {
    //        healthBarSlider.value -= .001f;  
    //    }
    //    else
    //    {
    //        isGameOver = true;    
    //        gameOverText.enabled = true; 
    //    }
    //}
}
