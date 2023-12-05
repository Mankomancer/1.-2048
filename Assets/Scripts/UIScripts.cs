using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //to use text mesh pro

public class UIScripts : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentScore;
    [SerializeField] TextMeshProUGUI highScore;
    [SerializeField] TextMeshProUGUI randomFact;
    
    
    // Start is called before the first frame update
    void Start()
    {
        currentScore.text = "0";
        GameObject.FindAnyObjectByType<RandomFactDisplayer>().DisplayRandomFact();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
