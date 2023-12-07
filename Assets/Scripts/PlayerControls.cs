using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] bool allowPlayerControl=true;
    public bool AllowPlayerControl{ //playing with this way how to isolate data
        get {return allowPlayerControl;}
        set {allowPlayerControl=value;}
    }


    float horizonatInput;
    float verticalInput;
    
    // Update is called once per frame
    void Update()
    {
        if (AllowPlayerControl){
            if (Input.GetKeyUp(KeyCode.W)){ //GetKeyUp is used, so doesnt accept input command all the time
                AllowPlayerControl=false;
                GameObject.FindAnyObjectByType<TilesManager>().MoveUp();
            }
            else if(Input.GetKeyUp(KeyCode.D)){
                AllowPlayerControl=false;
                GameObject.FindAnyObjectByType<TilesManager>().MoveRight();
            }
            else if(Input.GetKeyUp(KeyCode.A)){
                AllowPlayerControl=false;
                GameObject.FindAnyObjectByType<TilesManager>().MoveLeft();
            }
            else if(Input.GetKeyUp(KeyCode.S)){
                AllowPlayerControl=false;
                GameObject.FindAnyObjectByType<TilesManager>().MoveDown();
            }
        }
    }

    
}
