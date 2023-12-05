using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Fun Fact", fileName ="New Fun Fact")]
public class FunFactsSO : ScriptableObject
{
    [TextArea(2,5)]
    [SerializeField] string funFact;

    public string GetFact(){
        return funFact;
    }
}
