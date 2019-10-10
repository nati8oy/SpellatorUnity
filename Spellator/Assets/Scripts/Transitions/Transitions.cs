using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transitions : MonoBehaviour
{

    public TransitionsSO transitionsObject;

    public bool fadeIn;
    public SpriteRenderer spriteRenderer;


    public Color _damageColour;
    public Color _flashColour;
    public Color _fadeColour;


    public float transitionSpeed;
    public float fadeSpeed;
    public float pulseSpeed;
    // Start is called before the first frame update
    void Start()
    {
        pulseSpeed = transitionsObject.defaultPulseSpeed;
        fadeSpeed = transitionsObject.defaultFadeSpeed;

        fadeIn = transitionsObject.fadeIn;
        spriteRenderer.color = _fadeColour;

        _fadeColour = transitionsObject.fadeColour;
        _damageColour = transitionsObject.damageColour;
        _flashColour = transitionsObject.flashColour;
        transitionSpeed = 0.02f;

    }


    public void FadeType(Color colourToFade, float speedOfTransition)
    {
        transitionSpeed = speedOfTransition;
        _fadeColour = colourToFade;
        _fadeColour.a = 1;
    }


    private void Update()
    {
        if (_fadeColour.a > 0 && fadeIn == true)
        {
            _fadeColour.a -= transitionSpeed;
        }

        /*
        if ((fadeUp==true) && (fadeColourAlpha.a < 1))
        {
            {
                fadeColourAlpha.a += transitionSpeed;
            }
        }

        else if ((fadeUp == false) && (fadeColourAlpha.a > 1))
        {
            fadeColourAlpha.a -= transitionSpeed;

        }*/
        spriteRenderer.color = _fadeColour;

    }

}
