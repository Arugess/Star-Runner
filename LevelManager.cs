using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public string levelToLoad;
    public GameObject currentSpawnPoint;
    public GameObject startPoint;
    public PlayerBase player;

	void Start ()
    {
        //Finds the player script.
        player = FindObjectOfType<PlayerBase>();
        
    }
	

	void Update ()
    {
        if (Score.scoreValue < 0)
        {
            RestartPlayer();


        }

    }

    public void RestartPlayer()
    {
        StartCoroutine("PlayerBegin");
    }

    public void RespawnPlayer()
    {

        StartCoroutine("RestartDelay");
    }

    public IEnumerator PlayerBegin()
    {
        yield return new WaitForSeconds(0.25f);
        Score.scoreValue = 0;
        player.transform.position = startPoint.transform.position;
        
    }

    public IEnumerator RestartDelay()
    {
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
        Score.scoreValue -= 1;
        player.transform.position = currentSpawnPoint.transform.position;
        player.gameObject.SetActive(true);
    }
}
