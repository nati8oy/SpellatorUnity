using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Level Object", menuName = "Level Manager")]


public class LevelManagerSO : ScriptableObject
{

    public enum Level {wordLength, firstLetter, lastLetter, specificWord }

    [Header("Level Data")]
    public int currentLevel;
    public List<int> allLevels = new List<int>();
    public string levelType;
    public int reward;

    public string levelDescription;
    
}
