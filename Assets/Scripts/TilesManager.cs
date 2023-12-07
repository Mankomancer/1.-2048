using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
    [SerializeField] private GameObject parentObject; //so all tiles spawn under parent object
    [SerializeField] GameObject tile2;  //used to spawn default tyles
    [SerializeField] GameObject playerControls;


    //Could use this to get coordinates for spawn points
    [SerializeField] GameObject[] cells;
    bool[] fieldRepresenter = new bool [16]; //field count.  true - fillable, false - not fillable

    int randomNumber;

    GameObject tileSpawn;


    void Start()
    {
        for (int i = 0; i<=15; i++){    //fill with default "empty" value
            fieldRepresenter[i]=true;
        }
        SpawnTile();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTile(){
        
        //check possible spawn number
        randomNumber = Random.Range(0,16);
        int i = 15;
        do{
            if (fieldRepresenter[randomNumber]){ //we found a field where a tile can spawn can stop operation
                break;
            }
            else{   //if we didnt find where tyle can spawn with first time then we pick next avaiable value
                if(randomNumber==15){
                    randomNumber=0;
                }
                else if(randomNumber<15){
                    randomNumber++;
                }
                i--;
            }
        }while(i!=0);

        if (!fieldRepresenter[randomNumber]){ //we double check if spawn point exists, if it doesnt then we leave this function
            //ADD YOU LOSE SCREEN HERE
            Debug.Log("You LOST");
            return;
        }

        UnityEngine.Vector2 randomPosition = new UnityEngine.Vector2 (cells[randomNumber].transform.position.x, cells[randomNumber].transform.position.y);
        tileSpawn = Instantiate(tile2, randomPosition, UnityEngine.Quaternion.identity,parentObject.transform);
        fieldRepresenter[randomNumber]=false;

        //if no number possible - game over

        //if number possible spawn tile
        
        /*  this works just commented out to test stuff
        randomNumber = Random.Range(0,16);
        UnityEngine.Vector2 randomPosition = new UnityEngine.Vector2 (cells[randomNumber].transform.position.x, cells[randomNumber].transform.position.y);
        tileSpawn = Instantiate(tile2, randomPosition, UnityEngine.Quaternion.identity,parentObject.transform);
        */
    }

    public void MoveRight(){

        SpawnTile(); //need to have new tile before player is allowed to move
        playerControls.GetComponent<PlayerControls>().AllowPlayerControl=true; //enables player movement only after all previous actions have been taken
    }

    public void MoveLeft(){

        SpawnTile();
        playerControls.GetComponent<PlayerControls>().AllowPlayerControl=true;
    }

    public void MoveUp(){

        SpawnTile();
        playerControls.GetComponent<PlayerControls>().AllowPlayerControl=true;
    }

    public void MoveDown(){

        SpawnTile();
        playerControls.GetComponent<PlayerControls>().AllowPlayerControl=true;
    }


}
