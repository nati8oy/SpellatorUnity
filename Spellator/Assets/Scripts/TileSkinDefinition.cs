using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tile Skin Objects", menuName = "Skin Definition")]


public class TileSkinDefinition : ScriptableObject
{
    public Color tileTextColour;
    public Color tileDisabledColour;
    public Color doubleLetterColour;
    public Color correctWordTextColour;
    public Color tripleLetterColour;
    public Sprite[] tileAgeSprites;
}
