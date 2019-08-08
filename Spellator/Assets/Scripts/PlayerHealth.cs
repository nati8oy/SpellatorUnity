using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    private float CurrentHealth;
    private float MaxHealth;

    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = 40f;
        CurrentHealth = MaxHealth;
        healthBar.value = CalculateHealth() ;
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
    

    public void DealDamage(float damageValue)
    {
        CurrentHealth -= damageValue;
        healthBar.value = CalculateHealth();

       
    }

    public void Heal(float healValue)
    {
        if (CurrentHealth <= MaxHealth)
        {
            CurrentHealth += healValue;
            healthBar.value = CalculateHealth();
        }

    }

    float CalculateHealth()
    {
        return CurrentHealth / MaxHealth;
    }
}
