using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Flexible UI Data")]
public class FlexibleUIData : ScriptableObject 


{

    public Sprite buttonSprite;
    public SpriteState buttonSpriteState;

    public Color defaultColour;
    public Sprite defaultIcon;

    public Color confirmColour;
    public Sprite confirmIcon;

    public Color declineColour;
    public Sprite declineIcon;

    public Color warningColour;
    public Sprite warningIcon;

}
