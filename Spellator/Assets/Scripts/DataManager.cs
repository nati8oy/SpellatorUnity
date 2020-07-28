using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    public static DataManager Instance;

	private bool noAds = false;
    public ConfigSO configData;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void AddGold(int amount)
	{
        configData.totalGoldAmount += amount;
		//Debug.Log("Gold: " + amount);
	}
	public void RemoveAds()
	{
		noAds = true;
		Debug.Log("Ads off: " + noAds);
	}



}
