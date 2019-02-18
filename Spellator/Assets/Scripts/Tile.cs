using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public Button buttonComponent;
    public Text letter;
    public Text points;

    private Color wordCorrectColour;

    //for the coroutine
    private float smoothing = 10f;
    private Transform target;

    public Vector3 startPosition;

    private int positionInRack;
    private Vector3 returnPos;

    private float moveSpeed;
    public float speed = 1.0F;
    public int PositionInRack

    {
        get { return positionInRack; }
        set { PositionInRack = value; }
    }

    private int tilePointValue;

    public int TilePointValue
    {
        get { return tilePointValue; }
    }



    //create the list of letters which this could be.

    void Start()
    {


        startPosition = gameObject.transform.position;


        //set the first target positon to move to
        target = TileManager.Instance.NextFreePos;

        //sets the letter and point text of each tile
        letter.text = InitDictionary.Instance.bag[Random.Range(0, 95)];
        points.text = InitDictionary.Instance.pointsDictionary[letter.text].ToString();

        tilePointValue = InitDictionary.Instance.pointsDictionary[letter.text];

        // Debug.Log("this tile value is:" + tilePointValue);


        moveSpeed = Time.deltaTime * speed;

    }


    public void ReturnTheTiles()
    {
       //
         //StartCoroutine(ReturnTile(startPosition));
    }

    public void HandleClick()


    {


        //check is the tile is selected or not. If it's not tagged as "selected" then add it to the word being made.
        if (gameObject.tag != "TileSelected")
        {


            //add this tile's Pos to the SelectedTiles list in TileManager
            TileManager.Instance.SelectedTiles.Add(transform.parent);
            //Debug.Log(transform.parent.ToString());


            //Debug.Log("The number of tiles selected is: " + TileManager.Instance.SelectedTiles.Count);


            //start spelling the word using the letter from this tile
            GameManager.Instance.CreateWord(letter.text);

            //if the word is longer than 3 letters, check if it's in the dictionary
            if (GameManager.Instance.WordBeingMade.Length >= 3)
            {
                GameManager.Instance.CheckWord();
            }

            gameObject.tag = "TileSelected";
            //this sets the next tile to be placed
            StartCoroutine(PlayTile(target));


            TileManager.Instance.PlayTiles();


            //add the score

            GameManager.Instance.LiveScore = GameManager.Instance.LiveScore + tilePointValue;
            GameManager.Instance.LiveScoreText.text = GameManager.Instance.LiveScore.ToString();
        }


    }

    //moves the tile to the correct position on the playing board
    IEnumerator PlayTile(Transform target)
    {
        target = TileManager.Instance.NextFreePos;
       // Debug.Log(target);

        while (Vector3.Distance(transform.position, target.position) > 0.05f)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, smoothing * Time.deltaTime);

            yield return null;
        }

    }



}