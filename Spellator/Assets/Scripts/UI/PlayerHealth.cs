using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int heartsRemaining;
    public int maxHearts;
    public GameObject[] hearts;

    private float CurrentHealth;
    private float MaxHealth;
    public Animator anim;

    public Slider healthBar;

    public GameObject[] shazams;
    public int maxShazams;
    public int shazamsRemaining;


    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = 40f;
        CurrentHealth = MaxHealth;
        healthBar.value = CalculateHealth() ;

        //maximum hearts available
        maxHearts = 5;
        heartsRemaining = maxHearts;

        maxShazams = 3;
        shazamsRemaining = maxShazams;
        
    }

    
    // Update is called once per frame
    void Update()
    {
     

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

    public void UpdateShazams()
    {

    }

    public void UpdateUIItem(string function)
    {




        //check the incoming string and if it's "add heart" add health. Otherwise remove a heart.
        if (function == "add shazam" && shazamsRemaining < maxShazams)
        {
            shazams[shazamsRemaining].SetActive(true);
            shazamsRemaining += 1;
            //Debug.Log("heart added " + heartsRemaining + " total");
        }

        else if (function == "remove shazam" && shazamsRemaining > 0)
        {
            shazamsRemaining -= 1;

            shazams[shazamsRemaining].GetComponent<Animator>().SetBool("RemoveHeart", true);
            //hearts[heartsRemaining].SetActive(false);
            //Debug.Log("heart removed! " + heartsRemaining + " remaining");
        }


        //check the incoming string and if it's "add heart" add health. Otherwise remove a heart.
        if (function=="add heart" && heartsRemaining< maxHearts)
        {
            hearts[heartsRemaining].SetActive(true);
            heartsRemaining += 1;
            //Debug.Log("heart added " + heartsRemaining + " total");
        }

        else if(function == "remove heart" && heartsRemaining > 0)
        {
            heartsRemaining -= 1;

            hearts[heartsRemaining].GetComponent<Animator>().SetBool("RemoveHeart", true);
            //hearts[heartsRemaining].SetActive(false);
            //Debug.Log("heart removed! " + heartsRemaining + " remaining");
        }

        //using the heart system
        if (heartsRemaining <= 0)
        {
            GameManager.Instance.GameOverMethod();
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
