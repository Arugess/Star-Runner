using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script controls the player and makes them continuosly move.// 
//It also allows the player to jump and change direction when they hit a wall.//
//It makes the player lose some of their sore when they take damage.//

public class PlayerBase : MonoBehaviour
{
    //Finds the LevelManager script.
    public LevelManager levelManager;


    //Health, speed and movement of player.
    public int maxHealth = 1;
    public float playerSpeed = 3.0f;
    private Rigidbody2D playerBody;
    private bool moveRight;
    private bool moveLeft;

    

    //Components to check if the player is on the ground.
    public Transform gcheckPoint;
    private float gcheckRadius = 0.05f;
    public LayerMask gLayer;
    private bool isOnGround;


    //Jumping power of player.
    public float jumpPower;

    //Wall check
    public Transform wcheckPoint;
    private float wcheckradius = 0.15f;
    public LayerMask wLayer;
    private bool isOnWall;


    

	
	void Start ()
    {
        //Finds the rigid body attached to the player.
        playerBody = GetComponent<Rigidbody2D>();
        moveLeft = false;

        //Looks for the LevelManager script.
        levelManager = FindObjectOfType<LevelManager>();

    }
	
	
	void Update ()
    {
        // Checks to see if the player is grounded.
        isOnGround = Physics2D.OverlapCircle(gcheckPoint.position, gcheckRadius, gLayer);

        // Checks to see if the player is on a wall.
        isOnWall = Physics2D.OverlapCircle(wcheckPoint.position, wcheckradius, wLayer);

        //If player is not on the ground, resets jumpPower to 7.
        if(isOnGround == false)
        {
            jumpPower = 7;
        }

        if(isOnGround == true)
        {
            //moveLeft = true;
            moveRight = true;
        }
        


        //Regular player jump when "Space" is tapped.
        if (Input.GetKeyUp(KeyCode.Space) && isOnGround)
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, jumpPower);


        }
    }


    private void FixedUpdate()
    {


        //If the player keeps holding down space, the jump will become greater.
        if(Input.GetKey(KeyCode.Space) && isOnGround)
        {
            jumpPower += 8 * Time.deltaTime;

            //This maxes out the jumping power. 
            if(jumpPower >= 12.0f)
            {
                jumpPower = 12.0f;
            }

        }

        //Changes the direction of the player jump movement and flips the chracter direction.
        if (Input.GetKeyDown(KeyCode.Space) && isOnWall && !isOnGround)
        {
            if (moveRight == true)
            {
                moveRight = false;
                Flip();
                playerBody.velocity = new Vector2(-5, 10);
            }

            //This changes the player jump direction back to the right after jumping to the left.
            else
            {
                moveRight = true;
                FlipBack();
                playerBody.velocity = new Vector2(6, 10);

            }

            
        }


        if (moveRight == true)
        {
            //Keeps player constantly moving right.
            moveLeft = false;
            playerBody.velocity = new Vector2(playerSpeed, playerBody.velocity.y);
            FlipBack();


        }

        if (moveLeft == true)
        {
            moveRight = false;
            playerBody.velocity = new Vector2(-playerSpeed, playerBody.velocity.y);
            Flip();
        }

    }

    //Flips the players direction to face left.
    private void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x = -4;
        transform.localScale = theScale;
    }

    //Flips the players direction to face right.
    private void FlipBack()
    {
        Vector3 theScale = transform.localScale;
        theScale.x = 4;
        transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Subtract score from player and bounce player back when touching enemy.
        if (collider.gameObject.tag == "Enemy")
        {
            moveRight = false;
            Score.scoreValue -= 1;
            playerBody.velocity = new Vector2(-5, 5);
        }

        //Pauses player movement.
        if(collider.gameObject.tag == "Pause"  && Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            moveRight = false;
        }


        //Autojump off an enemy.
        if (collider.gameObject.tag == "Killbox")
        {
            //Bounce off enemy and increase score.
            playerBody.velocity = new Vector2(playerBody.velocity.x, 10);
            Score.scoreValue += 1;
        }
     
        //Kill player when falling in a pit.
        if (collider.gameObject.tag == "DropZone")
        {
            
            levelManager.RespawnPlayer();
        }

        //Makes player bounce off spikes.
        if(collider.gameObject.tag =="Spikes")
        {
            moveRight = false;
            Score.scoreValue -= 2;
            playerBody.velocity = new Vector2(-8, 10);
        }

        //Initiate contact with wall.
        if (collider.gameObject.tag == "Wall")
        {
            isOnWall = true;
           
        }

    }

}
