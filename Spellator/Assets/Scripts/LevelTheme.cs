using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Level Theme", menuName = "Theme")]

[System.Serializable]

public class LevelTheme : ScriptableObject
{
    public Sprite[] bgImage;
    public Sprite[] pointScreenImage;

}
