﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DragAndDrop : MonoBehaviour
{
    private bool selected;

    
    void Start()
    {
        //Fetch the Event Trigger component from your GameObject
        EventTrigger trigger = GetComponent<EventTrigger>();
        //Create a new entry for the Event Trigger
        EventTrigger.Entry entry = new EventTrigger.Entry();
        //Add a Drag type event to the Event Trigger
        entry.eventID = EventTriggerType.Drag;
        //call the OnDragDelegate function when the Event System detects dragging
        entry.callback.AddListener((data) => { OnDragDelegate((PointerEventData)data); });
        //Add the trigger entry
        trigger.triggers.Add(entry);
    }

    public void OnDragDelegate(PointerEventData data)
    {

        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cursorPos.x, cursorPos.y);

        //Create a ray going from the camera through the mouse position
        Ray ray = Camera.main.ScreenPointToRay(data.position);
        //Calculate the distance between the Camera and the GameObject, and go this distance along the ray
        Vector3 rayPoint = ray.GetPoint(Vector3.Distance(transform.position, Camera.main.transform.position));
        //Move the GameObject when you drag it
        transform.position = rayPoint;
    }
    

        /*

    public void DraggingFunction()
    {
        transform.position = new Vector3(cursorPos.x, cursorPos.y);
        Debug.Log(Input.mousePosition);
        //Debug.Log("cursorX: " + cursorPos.x + "cursorY:" + cursorPos.y);
    }
    */
    /*
void Update()
    {

        if (selected)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cursorPos.x, cursorPos.y);
            Debug.Log("moving");
        }
        if (Input.GetMouseButtonUp(0))
        {
            selected = false;
        }
    }

    private void OnMouseOver()
    {
        Debug.Log("hovering");
        if (Input.GetMouseButtonDown(0))
        {
            selected = true;
        }
    }*/

}