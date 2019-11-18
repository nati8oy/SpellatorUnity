using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollList : MonoBehaviour
{


    [Header("Scriptable objects")]
    private GameObject listObject;
    public ConfigSO configObject;
    public Transform listTransform;

    public string listType;
    public List<string> mainWordList = new List<string>();

    [Header("List variables")]
    public string listTitle;
    public string subtitle;
    public int listLength;


    [Header("Text boxes")]
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI subtitleText;

    public static TextMeshProUGUI wordText;



    [SerializeField] private GameObject closeButton;
    public bool closeButtonActive;


    // Start is called before the first frame update
    void Start()
    {
        //get the words out of the scriptable object
        mainWordList = configObject.uniqueWordsList;

        switch (listType)
        {
            case "word":
                //Debug.Log("enum type: word");


                for (int i = 0; i < configObject.uniqueWordsList.Count; i++)
                {
                    listObject = ObjectPooler.SharedInstance.GetPooledObject("Word List");
                    if (listObject != null)
                    {
                        listObject.transform.position = gameObject.transform.position;
                        listObject.transform.SetParent(listTransform.transform);

                        //set the value of the text box in the prefab to be the word from the list
                        var numberAndWordString = (i+1).ToString() + ". " + mainWordList[i];

                        listObject.GetComponent<TextMeshProUGUI>().text = numberAndWordString;

                        listObject.SetActive(true);
                        

                    }
                }


                break;

            case "achievement":
                //Debug.Log("enum type: achievement");

                for (int i = 0; i < listLength; i++)
                {
                    listObject = ObjectPooler.SharedInstance.GetPooledObject("Achievement");
                    if (listObject != null)
                    {

                        listObject.transform.position = gameObject.transform.position;
                        listObject.transform.SetParent(listTransform.transform);
                        //set the value of the text box in the prefab to be the word from the list
                        listObject.SetActive(true);

                    }
                }

                break;
        }


        //set the list title and subtitle
        titleText.text = listTitle;
        subtitleText.text = subtitle;

        //set the close button to active or inactive
        closeButton.SetActive(closeButtonActive);

        
    }

    public void HideScrollList()
    {
        gameObject.SetActive(false);
    }
}
