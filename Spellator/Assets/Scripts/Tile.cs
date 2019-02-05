using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public Button buttonComponent;
    public Text letter;
    public Text points;



    //for the coroutine
    public float smoothing = 5f;
    private Transform target;

    public Transform startPosition;

    private int nextPlayPosition;

   

    public List<string> letters = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };


    public Dictionary<string, int> pointsDictionary = new Dictionary<string, int>();



    //create the list of letters which this could be.

    void Start()
    {

        //set the first target positon to move to
        target = TileManager.Instance.playPositions[nextPlayPosition];
        //startPosition.position = transform.position;

        // target = GameManager.Instance.movePos;

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
        


    }


    public void HandleClick()


    {
        TileManager.Instance.MoveTiles();
        StartCoroutine(PlayTile(target));


        Debug.Log(nextPlayPosition);

        nextPlayPosition += 1;

        //check is the tile is selected or not. If it's not tagged as "selected" then add it to the word being made.
        if (gameObject.tag != "TileSelected")
        {

            target = TileManager.Instance.playPositions[nextPlayPosition];

            GameManager.Instance.CreateWord(letter.text);

            if(GameManager.Instance.WordBeingMade.Length >= 3)
            {
                GameManager.Instance.CheckWord();
            }

            gameObject.tag = "TileSelected";


        }



    }


    IEnumerator PlayTile(Transform target)
    {
        while (Vector3.Distance(transform.position, target.position) > 0.05f)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, smoothing * Time.deltaTime);

            yield return null;
        }

        print("Reached the target.");

        yield return new WaitForSeconds(1f);

        print("MyCoroutine is now finished.");
    }




}
