using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    GameObject[] pauseObjects;
           // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        HidePaused();
    }

    // Update is called once per frame
    void Update()
    {

        //uses the p button to pause and unpause the game
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (System.Math.Abs(Time.timeScale - 1.0f) < Mathf.Epsilon)
            {
                Time.timeScale = 0;
                ShowPaused();
            }
            else if (System.Math.Abs(Time.timeScale) < Mathf.Epsilon)
            {
                Debug.Log("high");
                Time.timeScale = 1;
                HidePaused();
            }
        }
    }


    //Reloads the Level
    public void Reload()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    //controls the pausing of the scene
    public void PauseControl()
    {
        if (System.Math.Abs(Time.timeScale - 1) < Mathf.Epsilon)
        {
            Time.timeScale = 0;
            ShowPaused();
        }
        else if (System.Math.Abs(Time.timeScale) < Mathf.Epsilon)
        {
            Time.timeScale = 1;
            HidePaused();
        }
    }

    //shows objects with ShowOnPause tag
    public void ShowPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public void HidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }
}
