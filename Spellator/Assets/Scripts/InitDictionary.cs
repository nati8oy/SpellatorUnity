using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitDictionary : MonoBehaviour
{

    public static InitDictionary instance = new InitDictionary();

    public Dictionary<string, int> points = new Dictionary<string, int>();

    void Start()
    {
        points.Add("A", 1);
        points.Add("B", 3);
        points.Add("C", 3);
        points.Add("D", 2);
        points.Add("E", 1);
        points.Add("F", 4);
        points.Add("G", 2);
        points.Add("H", 4);
        points.Add("I", 1);
        points.Add("J", 8);
        points.Add("K", 5);
        points.Add("L", 1);
        points.Add("M", 3);
        points.Add("N", 1);
        points.Add("O", 1);
        points.Add("P", 3);
        points.Add("Q", 10);
        points.Add("R", 1);
        points.Add("S", 1);
        points.Add("T", 1);
        points.Add("U", 1);
        points.Add("V", 4);
        points.Add("W", 4);
        points.Add("X", 8);
        points.Add("Y", 4);
        points.Add("Z", 10);




    }

    void Update()
    {
        
    }
}
