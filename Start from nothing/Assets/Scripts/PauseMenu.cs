using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    bool paused = false;

    public GameObject pauseOverlay;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            paused = togglePause();
        }
    }


    bool togglePause()
    {
        if(Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            Debug.Log("Unpaused Game");
            pauseOverlay.SetActive(false);
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            Debug.Log("Paused Game");
            pauseOverlay.SetActive(true);
            return (true);
        }
    }
}
