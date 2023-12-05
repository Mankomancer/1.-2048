using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class RandomFactDisplayer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI funFactTextField;
    [SerializeField] List<FunFactsSO> funFacts;
    string currentFact;
    int factCount;
    int randomNumber;

    public void DisplayRandomFact(){
        randomNumber = UnityEngine.Random.Range(0, factCount);
        currentFact = funFacts[randomNumber].GetFact();
        funFactTextField.text = currentFact; 
    }
    
    void Awake() {
        factCount=funFacts.Count;
    }
}
