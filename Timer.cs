using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public string reloadLevel;
    Text time;
    public float theTimer = 200.0f;

    void Start ()
    {
        time = GetComponent<Text>();
    }
	

	void Update ()
    {
        //Counts own time in whole seconds.
        time.text = "Time: " + Mathf.Round(theTimer -= Time.deltaTime);


       /* if(theTimer <= 0)
        {
            RestartCoroutine();
        }*/
    }

   /* public void RestartCoroutine()
    {
        StartCoroutine("GameRestart");
    }

    public IEnumerator GameRestart()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(reloadLevel);
        theTimer = 200.0f;

    }*/
}
