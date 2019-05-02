using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{

    [SerializeField] private ParticleSystem pe;

    private ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPS()
    {
        ps = Instantiate(pe, new Vector3(GameObject.Find("Word Being Spelled").transform.position.x, GameObject.Find("Word Being Spelled").transform.position.y), Quaternion.identity );
        //ps = pe;
        ps.transform.parent = transform;
        Debug.Log("particles up!");
    }
}
