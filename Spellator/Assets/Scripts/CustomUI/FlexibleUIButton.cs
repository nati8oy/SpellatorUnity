using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]

public class FlexibleUIButton : FlexibleUI
{

    public enum ButtonType
    {
        Default, Confirm, Decline, Warning
    }

    Image image;
    Image icon;
    Button button;
    public ButtonType buttonType;

    protected override void OnSkinUI()
    {
        base.OnSkinUI();

        image = GetComponent<Image>();
        icon = transform.Find("Icon").GetComponent<Image>();
        button = GetComponent<Button>();

        button.transition = Selectable.Transition.SpriteSwap;
        button.targetGraphic = image;

        image.sprite = skinData.buttonSprite;
        image.type = Image.Type.Sliced;
        button.spriteState = skinData.buttonSpriteState;


        switch (buttonType)
        {
            case ButtonType.Default:
                image.color = skinData.defaultColour;
                icon.sprite = skinData.defaultIcon;
                break;

            case ButtonType.Decline:
                image.color = skinData.declineColour;
                icon.sprite = skinData.declineIcon;
                break;

            case ButtonType.Confirm:
                image.color = skinData.confirmColour;
                icon.sprite = skinData.confirmIcon;
                break;

            case ButtonType.Warning:
                image.color = skinData.warningColour;
                icon.sprite = skinData.warningIcon;
                break;
        }

    
    }

}
