using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //Score for player.
    public static int scoreValue = 0;
    Text score;


	void Start ()
    {
        //Gets text from attached object.
        score = GetComponent<Text>();

	}

	void Update ()
    {
        //Adds value to increase the text number.
        score.text = "Score: " + scoreValue;

	}

}
