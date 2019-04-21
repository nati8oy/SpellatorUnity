using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{

    public class TileAttributes
    {

        public int testValue;

        public TileAttributes(int subTest)
        {
            testValue = subTest;
        }
    }

    public TileAttributes tileData = new TileAttributes(20);


    public Button buttonComponent;
    public Text letter;
    public Text points;

    private Color wordCorrectColour;

    private string tileColour;

    public string TileColour
    {
        get { return tileColour; }
    }

    [SerializeField] private Image blueDot;
    [SerializeField] private Image redDot;

    [SerializeField] private AudioClip tileClick;

    //for the coroutine
    private float smoothing = 10f;
    private Transform target;

    public Transform startPosition;

    private int chooseColour;

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



        /*
        //select a random colour of red or blue for the tiles
        chooseColour = Random.Range(1, 3);

        if (chooseColour == 1)
        {
            tileColour = "blue";
            blueDot.gameObject.SetActive(true);

        } else if (chooseColour == 2)   
        {
            tileColour = "red";
            redDot.gameObject.SetActive(true);
        }

        */

        //Debug.Log(chooseColour);

        wordCorrectColour = Color.red;

        //letter.color = wordCorrectColour;


        startPosition = gameObject.transform;
       // Debug.Log("start positon of this tile is: " + startPosition.position);


        //set the first target positon to move to
        target = TileManager.Instance.NextFreePos;



        //sets the letter and point text of each tile
        letter.text = InitDictionary.Instance.bag[Random.Range(0, 95)];
        points.text = InitDictionary.Instance.pointsDictionary[letter.text].ToString();

        tilePointValue = InitDictionary.Instance.pointsDictionary[letter.text];

        // Debug.Log("this tile value is:" + tilePointValue);


        moveSpeed = Time.deltaTime * speed;

    }

    public void HandleClick()


    {

       // if(DictionaryManager.Instance.StartLetter == )





            AudioManager.Instance.PlayAudio(tileClick);

            //check is the tile is selected or not. If it's not tagged as "selected" then add it to the word being made.
            if (gameObject.tag != "TileSelected")
            {


                //add this tile's Pos to the SelectedTiles list in TileManager
                TileManager.Instance.SelectedTiles.Add(transform.parent);
                //Debug.Log(transform.parent.ToString());


                //Debug.Log("The number of tiles selected is: " + TileManager.Instance.SelectedTiles.Count);


                //start spelling the word using the letter from this tile
                DictionaryManager.Instance.CreateWord(letter.text);

                //if the word is longer than 3 letters, check if it's in the dictionary
                if (DictionaryManager.Instance.WordBeingMade.Length >= 3)
                {
                    DictionaryManager.Instance.CheckWord();
                }

                gameObject.tag = "TileSelected";


                //////////////////
                ///THIS IS THE SECTION WHERE THE TILE PARENT is changed to be the main 
                /////////////////
                //gameObject.transform.parent = TileManager.Instance.ActiveWordPosition;
                //this sets the next tile to be placed
                StartCoroutine(PlayTile(TileManager.Instance.NextFreePos));

                //sets the next free position to the TileManage.Instance.selectedTiles length

                TileManager.Instance.PlayTiles();
                

                //add the score

                GameManager.Instance.LiveScore = GameManager.Instance.LiveScore + tilePointValue;
                GameManager.Instance.LiveScoreText.text = GameManager.Instance.LiveScore.ToString();




                //AudioManager.Instance.audioSource.PlayOneShot(AudioManager.Instance.tileClick);



        }


    }

  

    //moves the tile to the correct position on the playing board
    public IEnumerator PlayTile(Transform target)
    {
        Debug.Log("coroutine started");
        while (Vector3.Distance(transform.position, target.position) > 0.05f)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, smoothing * Time.deltaTime);

            /*Debug.Log(Vector3.Distance(transform.position, target.position));*/
            yield return null;
        }

    }

}