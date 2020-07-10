using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MultiplierScript : MonoBehaviour
{
    public TextMeshProUGUI multiplierAmount;


    // Update is called once per frame
    void Update()
    {
        multiplierAmount.text = "x" + Points.multiplier.ToString();

    }
}
