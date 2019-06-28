using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCreator : MonoBehaviour
{
    [SerializeField] private GameObject tile;
    private GameObject newTile;
    public Transform startPos;
    private TileSpawnerClass tileSpawner;

    private GameObject starParticles;

    private bool available = true;

    public bool Available
    {
        get { return available; }
        set { Available = value; }
    }

    private void Start()
    {
        newTile = ObjectPooler.SharedInstance.GetPooledObject("Tile");
        startPos = gameObject.transform;

        
        TileSpawnerClass tileSpawner = new TileSpawnerClass();
        tileSpawner.GetNewPooledObject(gameObject.transform.position, gameObject.transform);

      
    }


    public void RefillTiles()
    {

        newTile = ObjectPooler.SharedInstance.GetPooledObject("Tile");

        if (newTile != null)
        {
            newTile.transform.position = gameObject.transform.position;
            newTile.transform.SetParent(gameObject.transform);
            newTile.SetActive(true);
            //available = false;

        }

        starParticles = ObjectPooler.SharedInstance.GetPooledObject("Particles");
        //starParticles.GetComponent<ParticleSystem>().Play();

        if (starParticles != null)
        {
            starParticles.transform.position = gameObject.transform.position;
           // starParticles.transform.SetParent(gameObject.transform);
            starParticles.SetActive(true);
            //available = false;
            StartCoroutine("CheckIfAlive");

        }


    }

    //resets the particle systems to be inactive so they can be reused in the object pool
    private IEnumerator CheckIfAlive()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            starParticles.SetActive(false);
            StopCoroutine("CheckIfAlive");
        }
    }
}
