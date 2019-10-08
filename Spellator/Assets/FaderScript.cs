using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaderScript : MonoBehaviour
{
    public Color alphaFadeColor;
    //public SpriteRenderer image;
    public SpriteRenderer image;
    public float fadeSpeed; 
    // Start is called before the first frame update

    private void Start()
    {
        image.color = alphaFadeColor;
        alphaFadeColor.a = 1;
        
    }
    // Update is called once per frame
    void Update()
    {

        if (alphaFadeColor.a > 0)
        {
            alphaFadeColor.a -= 0.01f;
        }

        image.color = alphaFadeColor;
    }
}
