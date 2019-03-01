using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAreaController : MonoBehaviour
{

    public Vector3 cameraPosition = Vector3.zero;
    public Transform target;
    private float moveSpeed = 0.3f;
   


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        cameraPosition = new Vector3(Mathf.SmoothStep(transform.position.x, target.transform.position.x, moveSpeed), Mathf.SmoothStep(transform.position.y, target.transform.position.y, moveSpeed));
    }

    private void LateUpdate()
    {
        //transform.position = cameraPosition + Vector3.forward * -10;
    } 

   
}
