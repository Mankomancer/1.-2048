using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
    [SerializeField] private GameObject parentObject; //so all tiles spawn under parent object
    [SerializeField] GameObject playerControls;
    [SerializeField] GameObject[] tilePrefabs;


    //Could use this to get coordinates for spawn points
    [SerializeField] GameObject[] cells;
    bool[] fieldRepresenter = new bool [16]; //field count.  true - fillable, false - not fillable
    int[] valuesInTiles = new int [16]; //to store values, so can use them to check if can merge them
    GameObject[] spawnedTiles = new GameObject[16]; //store spawned and combined tiles here
    int randomNumber;
    GameObject tileSpawn;

    int destinationTile;
    int movingTile;
    GameObject mergedTile;


    void Start()
    {
        for (int i = 0; i<=15; i++){    //fill with default "empty" value
            fieldRepresenter[i]=true;
            valuesInTiles[i]=0;
        }
        SpawnTile();

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
        tileSpawn = Instantiate(tilePrefabs[0], randomPosition, UnityEngine.Quaternion.identity,parentObject.transform);
        spawnedTiles[randomNumber] = tileSpawn;
        valuesInTiles[randomNumber]= 2;
        fieldRepresenter[randomNumber]=false;
    }

    /*
    Logic tied with moving tiles. We use array as representation:
    0   1   2   3
    4   5   6   7
    8   9   10  11
    12  13  14  15

    So if we want to move tiles to the right we need to exceute these orders in specific order (this example doesnt include if tile needs to be moved more than 1 tile  )

    2->3	1->2	0->1
    6->7	5->6	4->5
    10->11	9->10	8->9
    14->15	13->14	12->13

    */

    public void MoveRight(){
        
        for (int i=0; i<4; i++){    //need to use i*4 - represents which line is used
            for (int j = 3; j>0; j--){
                destinationTile=j+i*4;
                movingTile=j-1+i*4;
                if (!spawnedTiles[destinationTile] && spawnedTiles[movingTile]){ //destination tile needs to be empty, moving tile needs to exists
                    
                    UnityEngine.Vector2 newCellPosition = new UnityEngine.Vector2(cells[destinationTile].transform.position.x, cells[destinationTile].transform.position.y);
                    TilesMover(destinationTile, movingTile);
                    spawnedTiles[destinationTile].transform.position=newCellPosition;
                }
                else if (!spawnedTiles[destinationTile] && !spawnedTiles[movingTile] && valuesInTiles[movingTile]==valuesInTiles[destinationTile]){
                    //we repeat same thing we did in previous if statement, maybe ?
                    UnityEngine.Vector2 newCellPosition = new UnityEngine.Vector2(cells[destinationTile].transform.position.x, cells[destinationTile].transform.position.y);
                    TileMerger(valuesInTiles[destinationTile]);//selects prefab for next merged tile
                    TilesMover(destinationTile, movingTile);    //moves


                }


            }
        }

        



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

    public void TilesMover(int destination, int mover){
        spawnedTiles[destination]=spawnedTiles[mover];
        spawnedTiles[mover]=null;
                    
        valuesInTiles[destination]=valuesInTiles[mover];
        valuesInTiles[mover]=0;

        fieldRepresenter[mover]=true;
        fieldRepresenter[destination]=false;
    }

    public void TileMerger(int previousNumber){
        if (previousNumber==2){
            mergedTile=tilePrefabs[0];
        }
        else if (previousNumber==4){
            mergedTile=tilePrefabs[1];
        }
        else if (previousNumber==8){
            mergedTile=tilePrefabs[2];
        }
        else if (previousNumber==16){
            mergedTile=tilePrefabs[3];
        }
        else if (previousNumber==32){
            mergedTile=tilePrefabs[4];
        }
        else if (previousNumber==64){
            mergedTile=tilePrefabs[5];
        }
        else if (previousNumber==128){
            mergedTile=tilePrefabs[6];
        }
        else if (previousNumber==256){
            mergedTile=tilePrefabs[7];
        }
        else if (previousNumber==512){
            mergedTile=tilePrefabs[8];
        }
        else if (previousNumber==1024){
            mergedTile=tilePrefabs[9];
        }
        else if (previousNumber==2048){
            mergedTile=tilePrefabs[10];
        }
    }

}
