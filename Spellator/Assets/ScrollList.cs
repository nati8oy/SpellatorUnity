using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollList : MonoBehaviour
{

    public string objectTag;
    private GameObject listObject;
    public ConfigSO configObject;
    public Transform listTransform;
    [SerializeField] private GameObject closeButton;
    public int listLength;
    public bool closeButtonActive = false;


    // Start is called before the first frame update
    void Start()
    {
        //set the close button to active or inactive
        closeButton.SetActive(closeButtonActive);

        for (int i = 0; i < listLength; i++)
        {
            listObject = ObjectPooler.SharedInstance.GetPooledObject(objectTag);
            if (listObject != null)
            {

                listObject.transform.position = gameObject.transform.position;
                listObject.transform.SetParent(listTransform.transform);
                //set the value of the text box in the prefab to be the word from the list
                listObject.SetActive(true);

            }
        }
    }

    public void HideScrollList()
    {
        gameObject.SetActive(false);
    }
}
