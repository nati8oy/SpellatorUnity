using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendButtonSpecific : MonoBehaviour
{
  public void SetInteractable()
    {
        gameObject.GetComponent<Button>().interactable = false;
    }
}
