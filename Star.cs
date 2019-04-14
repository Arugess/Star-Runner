using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will increase the players score each time they collect a star.//

public class Star : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Score.scoreValue += 1;
            Destroy(gameObject);
        }
    }
}
