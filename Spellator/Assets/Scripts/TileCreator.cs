using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCreator : MonoBehaviour
{
    private GameObject newTile;
    public Transform startPos;
    private TileSpawnerClass tileSpawner;

    private GameObject smokeParticles;

    private bool available = true;
    public bool Available
    {
        get { return available; }
        set { Available = value; }
    }

    private void Start()
    {
       

        //Remember that the object pooler uses TAGS not names of objects to set them active, etc. here.
        newTile = ObjectPooler.SharedInstance.GetPooledObject("Tile");
        startPos = gameObject.transform;


        TileSpawnerClass tileSpawner = new TileSpawnerClass();
        tileSpawner.GetNewPooledObject(gameObject.transform.position, gameObject.transform);

        //add this game object to the list of objects in the rack
       // LevelManager.Instance.currentRackTileTypes.Add(gameObject);
        //Debug.Log(LevelManager.Instance.currentRackTileTypes.Count);
      
    }                                                                                   


    public void RefillTiles()
    {

        //Remember that the object pooler uses TAGS not names of objects to set them active, etc. here.
        newTile = ObjectPooler.SharedInstance.GetPooledObject("Tile");

        if (newTile != null)
        {
            newTile.transform.position = gameObject.transform.position;
            newTile.transform.SetParent(gameObject.transform);
            newTile.SetActive(true);
           
            //available = false;

        }
        //Debug.Log(LevelManager.Instance._levelComplete);
        //don't add the particles if the level is complete
        if(LevelManager.Instance._levelComplete != true)
        {

            //Remember that the object pooler uses TAGS not names of objects to set them active, etc. here.
            smokeParticles = ObjectPooler.SharedInstance.GetPooledObject("Smoke");
            //smokeParticles.GetComponent<ParticleSystem>().Play();

            if (smokeParticles != null)
            {
                smokeParticles.transform.position = gameObject.transform.position;
               // smokeParticles.transform.SetParent(gameObject.transform);
                smokeParticles.SetActive(true);
                //available = false;
                StartCoroutine("CheckIfAlive");

            }

        }

    }

    //resets the particle systems to be inactive so they can be reused in the object pool
    private IEnumerator CheckIfAlive()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            smokeParticles.SetActive(false);
            StopCoroutine("CheckIfAlive");
        }
    }
}
