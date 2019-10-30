﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabMapReader : MonoBehaviour
{
   // public TabMap tabmap;

    public GameObject tab1;
    public GameObject tab2;
    public GameObject tab3;
    public GameObject tab4;


    //public GameObject activeTab;
    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log(tab1);

    }


    public void TabSelector(string tabName)
    {
        switch (tabName)
        {
            case "a":
                Debug.Log("a");
                tab1.SetActive(true);
                tab2.SetActive(false);
                tab3.SetActive(false);
                tab4.SetActive(false);


                break;
            case "b":
                Debug.Log("b");
                tab1.SetActive(false);
                tab2.SetActive(true);
                tab3.SetActive(false);
                tab4.SetActive(false);
                break;
            case "c":
                Debug.Log("c");
                tab1.SetActive(false);
                tab2.SetActive(false);
                tab3.SetActive(true);
                tab4.SetActive(false);
                break;
            case "d":
                Debug.Log("d");
                tab1.SetActive(false);
                tab2.SetActive(false);
                tab3.SetActive(false);
                tab4.SetActive(true);
                break;
        }


    }
}