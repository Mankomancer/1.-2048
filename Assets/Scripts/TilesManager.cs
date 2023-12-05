using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
    [SerializeField] private GameObject parentObject; //so all tiles spawn under parent object
    [SerializeField] GameObject tile2;

    //Could use this to get coordinates for spawn points
    [SerializeField] GameObject[] cells;

    int randomNumber;
    GameObject spawnTile;


    void Start()
    {
        randomNumber = Random.Range(0,16);
        UnityEngine.Vector2 randomPosition = new UnityEngine.Vector2 (cells[randomNumber].transform.position.x, cells[randomNumber].transform.position.y);
        spawnTile = Instantiate(tile2, randomPosition, UnityEngine.Quaternion.identity,parentObject.transform);
        
        /*GameObject spawn;
        Vector2 randomPosition = new Vector2(Random.Range(-5,5), Random.Range(-5,5));
        spawn = Instantiate(tile2, randomPosition ,Quaternion.identity,parentObject.transform);
        */

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTile(){

    }

    public void MoveRight(){

    }

    public void MoveLeft(){

    }

    public void MoveUp(){

    }

    public void MoveDown(){

    }


}
