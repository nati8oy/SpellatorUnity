using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public Button buttonComponent;
    public Text letter;
    public Text points;
    private Color newColor = Color.red;
    private ColorBlock cb;
    //private bool selected = false;
    private string currentWord;
    public List<string> letters = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };


    public Dictionary<string, int> pointsDictionary = new Dictionary<string, int>();



    //create the list of letters which this could be.

    void Start()
    {

        pointsDictionary.Add("A", 1);
        pointsDictionary.Add("B", 3);
        pointsDictionary.Add("C", 3);
        pointsDictionary.Add("D", 2);
        pointsDictionary.Add("E", 1);
        pointsDictionary.Add("F", 4);
        pointsDictionary.Add("G", 2);
        pointsDictionary.Add("H", 4);
        pointsDictionary.Add("I", 1);
        pointsDictionary.Add("J", 8);
        pointsDictionary.Add("K", 5);
        pointsDictionary.Add("L", 1);
        pointsDictionary.Add("M", 3);
        pointsDictionary.Add("N", 1);
        pointsDictionary.Add("O", 1);
        pointsDictionary.Add("P", 3);
        pointsDictionary.Add("Q", 10);
        pointsDictionary.Add("R", 1);
        pointsDictionary.Add("S", 1);
        pointsDictionary.Add("T", 1);
        pointsDictionary.Add("U", 1);
        pointsDictionary.Add("V", 4);
        pointsDictionary.Add("W", 4);
        pointsDictionary.Add("X", 8);
        pointsDictionary.Add("Y", 4);
        pointsDictionary.Add("Z", 10);


        letter.text = letters[Random.Range(0,25)];
        points.text = pointsDictionary[letter.text].ToString();

        //buttonComponent.onClick.AddListener(HandleClick);



    }



    public void HandleClick()


    {
        //check is the tile is selected or not. If it's not tagged as "selected" then add it to the word being made.
        if(gameObject.tag != "Selected")
        {

            GameManager.Instance.CreateWord(letter.text);

            if(GameManager.Instance.WordBeingMade.Length >= 3)
            {
                GameManager.Instance.CheckWord();
            }

            gameObject.tag = "Selected";


        }



    }


}
