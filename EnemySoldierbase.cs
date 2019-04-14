using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoldierbase : MonoBehaviour
{
    //Enemy stats.
    private Rigidbody2D enemyBody;
   
    /*//checks for walls
    public Transform wCheckPointE;
    public LayerMask wLayerE;
    private float wCheckRadiusE = 0.1f;
    private bool touchWall;*/
    private bool moveLeft;
    public int enemySpeed = 1;


    void Start ()
    {

        enemyBody = GetComponent<Rigidbody2D>();
        
        moveLeft = true;
    }
	

	void Update ()
    {
        /*//Checks if the enemy has touched a wall.
        touchWall = Physics2D.OverlapCircle(wCheckPointE.position, wCheckRadiusE, wLayerE);
        */

	}

    private void FixedUpdate()
    {
        /*//Initiates when an enemy hits a wall.
        if (touchWall)
        {
            //Makes enemy run right.
            if (moveLeft)
            {
                moveLeft = false;
            }

            //Makes enemy turn left.
            else if (!moveLeft)
            {
                moveLeft = true;
            }
        }*/



        //Makes enemy move left.
        if (moveLeft)
        {
            Vector3 otherScale = transform.localScale;
            otherScale.x = -4;
            transform.localScale = otherScale;

            enemyBody.velocity = new Vector2(-enemySpeed, enemyBody.velocity.y);
        }

        //Makes enemy move right.
        else
        {
            Vector3 otherScale = transform.localScale;
            otherScale.x = 4;
            transform.localScale = otherScale;

            enemyBody.velocity = new Vector2(enemySpeed, enemyBody.velocity.y);
        }    
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Wall" && moveLeft)
        {
            moveLeft = false;
        }

        else 
        {
            moveLeft = true;
        }


    }

}
