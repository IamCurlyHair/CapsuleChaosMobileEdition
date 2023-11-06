using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int theScore = 0;
    Text scoreValue;


    private void Start()
    {
        scoreValue = GetComponent<Text>();
    }
    private void Update()
    {
        scoreValue.text = "COINS COLLECTED : " + theScore;
    }
    
}
