using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Word Data", menuName = "Word List")]
public class ConfigSO : ScriptableObject
{
    public List<string> uniqueWordsList;
    public bool soundOn;
    public bool musicOn;


}
