using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int heartsRemaining;
    public int maxHearts;

    private float CurrentHealth;
    private float MaxHealth;
    public Animator anim;

    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = 40f;
        CurrentHealth = MaxHealth;
        healthBar.value = CalculateHealth() ;

        //maximum hearts available
        maxHearts = 5;
        heartsRemaining = maxHearts;
        
    }

    
    // Update is called once per frame
    void Update()
    {
        //using the heart system
        if(heartsRemaining <= 0)
        {
            GameManager.Instance.GameOverMethod();
        }




        if (CurrentHealth <= 0)
        {
            GameManager.Instance.GameOverMethod();
            CurrentHealth = 100;
        }

        
        if (Input.GetKeyDown("1")){
            DealDamage(5);
        }

        if (Input.GetKeyDown("2")){
            Heal(5);
        }

    }

    public void UpdateHearts(string function)
    {
        //check the incoming string and if it's "add heart" add health. Otherwise remove a heart.
        if(function=="add heart" && heartsRemaining< maxHearts)
        {
            heartsRemaining += 1;
            Debug.Log("heart added " + heartsRemaining + " total");
        }

        else if(function == "remove heart" && heartsRemaining > 0)
        {
            heartsRemaining -= 1;
            Debug.Log("heart removed! " + heartsRemaining + " remaining");
        }
    }
    

    public void DealDamage(float damageValue)
    {
        CurrentHealth -= damageValue;
        healthBar.value = CalculateHealth();
        anim.SetBool("HealthAdjust", true);
       
    }

    public void Heal(float healValue)
    {
        if (CurrentHealth <= MaxHealth)
        {
            CurrentHealth += healValue;
            healthBar.value = CalculateHealth();
        }

        anim.SetBool("HealthAdjust", true);
//        Debug.Log("healed " +healValue + " points");

    }

    float CalculateHealth()
    {
        return CurrentHealth / MaxHealth;
    }



}
